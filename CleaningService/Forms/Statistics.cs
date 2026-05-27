using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CleaningService.Forms
{
    public partial class Statistics : Form
    {
        private OrderEmployee employeeManager;
        private CleaningCompany _company;
        private string _savePath;

        public Statistics(OrderEmployee manager, CleaningCompany company, string path)
        {
            InitializeComponent();

            employeeManager = manager;
            _company = company;
            _savePath = path;

            BackColor = Color.Honeydew;
            StartPosition = FormStartPosition.CenterScreen;

            Load += Statistics_Load;
            InitLabelEvents();
        }

        private void InitLabelEvents()
        {
            label10.Click += LabelIncome_Click;
            label11.Click += LabelAverage_Click;
            label12.Click += LabelOrders_Click;

            label13.Click += LabelPayment_Click;
            label14.Click += LabelPayment_Click;
            label15.Click += LabelPayment_Click;
            label16.Click += LabelPayment_Click;

            label10.Cursor = Cursors.Hand;
            label11.Cursor = Cursors.Hand;
            label12.Cursor = Cursors.Hand;
            label13.Cursor = Cursors.Hand;
            label14.Cursor = Cursors.Hand;
            label15.Cursor = Cursors.Hand;
            label16.Cursor = Cursors.Hand;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            LoadGeneralStatistics();
            LoadPaymentStatistics();
            LoadEmployeeStatistics();
            LoadCharts();
        }

        private void OrderEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMainForm form = new EmployeeMainForm(employeeManager, _company, _savePath);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void OrderAdministrationMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadGeneralStatistics()
        {
            double totalIncome = _company.GetTotalIncome();
            int totalOrders = _company.Orders.Count;
            double average = totalOrders > 0 ? totalIncome / totalOrders : 0;

            label10.Text = $"{totalIncome:0.00} грн";
            label11.Text = $"{average:0.00} грн";
            label12.Text = totalOrders.ToString();
        }

        private void LoadPaymentStatistics()
        {
            label13.Text = _company.Orders.Count(o => GetPaymentStatus(o) == "Оплачено").ToString();
            label14.Text = _company.Orders.Count(o => GetPaymentStatus(o) == "Неоплачено").ToString();
            label15.Text = _company.Orders.Count(o => GetPaymentStatus(o) == "Частково сплачено").ToString();
            label16.Text = _company.Orders.Count(o => GetPaymentStatus(o) == "Очікує оплати").ToString();
        }

        private void LoadEmployeeStatistics()
        {
            comboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
            comboBox1.Items.Clear();

            foreach (var emp in employeeManager.Employees)
                comboBox1.Items.Add(emp);

            comboBox1.DisplayMember = "EmployeeName";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            else
            {
                label20.Text = "0";
                label21.Text = "0 грн";
                ResetChart(chart1, "Статистика фахівця", "", "");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not Employee emp) return;

            label20.Text = emp.GetOrdersCount().ToString();
            label21.Text = $"{emp.GetSalary():0.00} грн";

            LoadEmployeeChart(emp);
        }

        private void LoadEmployeeChart(Employee emp)
        {
            ResetChart(chart1, $"Фахівець: {emp.EmployeeName}", "Показник", "Значення");

            var series = CreateSeries("Фахівець");
            series.Points.AddXY("Замовлення", emp.GetOrdersCount());
            series.Points.AddXY("Зарплата", emp.GetSalary());

            chart1.Series.Add(series);
        }

        private void LoadCharts()
        {
            LoadIncomeByMonthsChart();
            LoadPaymentChart();
            LoadAverageCheckByWeeksChart();
            LoadEmployeesChart();
        }

        private void LoadIncomeByMonthsChart()
        {
            ResetChart(chart2, "Дохід по місяцях", "Місяць", "Дохід, грн");

            var series = CreateSeries("Дохід");

            var data = _company.Orders
                .GroupBy(o => GetOrderDate(o).Month)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Month = g.Key,
                    Income = g.Sum(o => GetOrderPrice(o))
                });

            foreach (var item in data)
                series.Points.AddXY(GetMonthName(item.Month), item.Income);

            chart2.Series.Add(series);
        }

        private void LoadAverageCheckByWeeksChart()
        {
            ResetChart(chart4, "Середній чек по тижнях", "Тиждень", "Середній чек, грн");

            var series = CreateSeries("Середній чек");

            var data = _company.Orders
                .GroupBy(o => GetWeekOfMonth(GetOrderDate(o)))
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Week = g.Key,
                    Average = g.Average(o => GetOrderPrice(o))
                });

            foreach (var item in data)
                series.Points.AddXY($"{item.Week} тиждень", item.Average);

            chart4.Series.Add(series);
        }

        private void LoadOrdersByWeeksChart()
        {
            ResetChart(chart2, "Кількість замовлень по тижнях", "Тиждень", "Кількість");

            var series = CreateSeries("Замовлення");

            var data = _company.Orders
                .GroupBy(o => GetWeekOfMonth(GetOrderDate(o)))
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Week = g.Key,
                    Count = g.Count()
                });

            foreach (var item in data)
                series.Points.AddXY($"{item.Week} тиждень", item.Count);

            chart2.Series.Add(series);
        }

        private void LoadPaymentChart()
        {
            ResetChart(chart3, "Статистика оплат замовлень", "Статус", "Кількість");

            var series = CreateSeries("Оплати");

            series.Points.AddXY("Оплачено", _company.Orders.Count(o => GetPaymentStatus(o) == "Оплачено"));
            series.Points.AddXY("Неоплачено", _company.Orders.Count(o => GetPaymentStatus(o) == "Неоплачено"));
            series.Points.AddXY("Частково", _company.Orders.Count(o => GetPaymentStatus(o) == "Частково сплачено"));
            series.Points.AddXY("Очікує", _company.Orders.Count(o => GetPaymentStatus(o) == "Очікує оплати"));

            chart3.Series.Add(series);
        }

        private void LoadServicesChart()
        {
            ResetChart(chart4, "Популярність послуг", "Послуга", "Кількість");

            var series = CreateSeries("Послуги");

            var services = _company.Orders
                .SelectMany(o => o.Services)
                .GroupBy(s => s.CategoryService)
                .Select(g => new { Service = g.Key, Count = g.Count() });

            foreach (var service in services)
                series.Points.AddXY(service.Service, service.Count);

            chart4.Series.Add(series);
        }

        private void LoadEmployeesChart()
        {
            ResetChart(chart5, "Топ фахівців за замовленнями", "Фахівець", "Кількість");

            var series = CreateSeries("Фахівці");

            foreach (var emp in employeeManager.GetTopEmployees())
                series.Points.AddXY(emp.EmployeeName, emp.GetOrdersCount());

            chart5.Series.Add(series);
        }

        private void LabelIncome_Click(object sender, EventArgs e)
        {
            LoadIncomeByMonthsChart();
        }

        private void LabelAverage_Click(object sender, EventArgs e)
        {
            ResetChart(chart2, "Середній чек по тижнях", "Тиждень", "Середній чек, грн");

            var series = CreateSeries("Середній чек");

            var data = _company.Orders
                .GroupBy(o => GetWeekOfMonth(GetOrderDate(o)))
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Week = g.Key,
                    Average = g.Average(o => GetOrderPrice(o))
                });

            foreach (var item in data)
                series.Points.AddXY($"{item.Week} тиждень", item.Average);

            chart2.Series.Add(series);
        }

        private void LabelOrders_Click(object sender, EventArgs e)
        {
            LoadOrdersByWeeksChart();
        }

        private void LabelPayment_Click(object sender, EventArgs e)
        {
            LoadPaymentChart();
        }

        private void ResetChart(Chart chart, string title, string xTitle, string yTitle)
        {
            chart.Series.Clear();
            chart.Titles.Clear();

            chart.Titles.Add(title);

            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("ChartArea1"));

            ChartArea area = chart.ChartAreas[0];

            area.AxisX.Title = xTitle;
            area.AxisY.Title = yTitle;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -25;
            area.AxisY.Minimum = 0;

            area.BackColor = Color.White;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private Series CreateSeries()
        {
            return CreateSeries("Дані");
        }

        private Series CreateSeries(string name)
        {
            var series = new Series(name)
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            SetThinColumns(series);
            return series;
        }

        private void SetThinColumns(Series series)
        {
            series["PixelPointWidth"] = "35";
        }

        private int GetWeekOfMonth(DateTime date)
        {
            return ((date.Day - 1) / 7) + 1;
        }

        private string GetMonthName(int month)
        {
            string[] months =
            {
                "Січень", "Лютий", "Березень", "Квітень",
                "Травень", "Червень", "Липень", "Серпень",
                "Вересень", "Жовтень", "Листопад", "Грудень"
            };

            return months[month - 1];
        }

        private string GetPaymentStatus(object order)
        {
            return GetStringProperty(order, "PaymentStatus") ?? "";
        }

        private DateTime GetOrderDate(object order)
        {
            object value =
                GetPropertyValue(order, "OrderDate") ??
                GetPropertyValue(order, "Date") ??
                GetPropertyValue(order, "DateOrder") ??
                GetPropertyValue(order, "CleaningDate") ??
                GetPropertyValue(order, "CreatedAt");

            if (value is DateTime date)
                return date;

            return DateTime.Now;
        }

        private double GetOrderPrice(object order)
        {
            object value =
                GetPropertyValue(order, "TotalPrice") ??
                GetPropertyValue(order, "Price") ??
                GetPropertyValue(order, "Cost") ??
                GetPropertyValue(order, "TotalCost") ??
                GetPropertyValue(order, "Amount");

            if (value == null)
                return 0;

            double.TryParse(value.ToString(), out double result);
            return result;
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null) return null;

            PropertyInfo prop = obj.GetType().GetProperty(propertyName);
            return prop?.GetValue(obj);
        }

        private string GetStringProperty(object obj, string propertyName)
        {
            object value = GetPropertyValue(obj, propertyName);
            return value?.ToString();
        }
    }
}