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
        private void LoadCharts()
        {
            LoadIncomeByMonthsChart();
            LoadPaymentChart();
            LoadServicesChart();
        }
        private void LoadIncomeByMonthsChart()
        {
            ResetChart(chart2, "Дохід по місяцях", "", "Дохід, грн");
            var series = CreateSeries("Дохід", SeriesChartType.Column);
            series.Color = Color.SeaGreen;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "0 грн";
            series.IsXValueIndexed = true;
            series["PixelPointWidth"] = "45";
            var data = _company.Orders
                .Where(o => o.OrderDate != DateTime.MinValue)
                .GroupBy(o => new DateTime(o.OrderDate.Year, o.OrderDate.Month, 1))
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    MonthDate = g.Key,
                    Income = g.Sum(o => o.Price)
                })
                .ToList();
            foreach (var item in data)
            {
                int index = series.Points.AddY(item.Income);
                series.Points[index].AxisLabel = $"{GetMonthName(item.MonthDate.Month)}\n{item.MonthDate.Year}";
                series.Points[index].Label = $"{item.Income:0} грн";
            }
            chart2.Series.Add(series);
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.AxisY.Minimum = 0;
            area.Position = new ElementPosition(8, 18, 88, 74);
            area.InnerPlotPosition = new ElementPosition(14, 8, 80, 68);
        }
        private void LoadAverageCheckByWeeksChart()
        {
            ResetChart(chart2, "Середній чек по тижнях", "", "Середній чек, грн");
            var series = CreateSeries("Середній чек", SeriesChartType.Column);
            series["LabelStyle"] = "Top";
            series.SmartLabelStyle.Enabled = false;
            series.Font = new Font("Georgia", 8, FontStyle.Bold);
            series.Color = Color.DodgerBlue;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "0 грн";
            series.IsXValueIndexed = true;
            series["PixelPointWidth"] = "45";
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime currentMonday = today.AddDays(-diff);
            DateTime startMonday = currentMonday.AddDays(-7);
            for (int i = 0; i < 4; i++)
            {
                DateTime weekStart = startMonday.AddDays(i * 7);
                DateTime weekEnd = weekStart.AddDays(6);
                var ordersInWeek = _company.Orders
                    .Where(o => o.OrderDate.Date >= weekStart.Date &&
                                o.OrderDate.Date <= weekEnd.Date)
                    .ToList();
                double average = ordersInWeek.Count > 0
                    ? ordersInWeek.Average(o => o.Price)
                    : 0;
                int index = series.Points.AddY(average);
                series.Points[index].AxisLabel =
                    $"{weekStart:dd.MM} - {weekEnd:dd.MM}";
                series.Points[index].Label = $"{average:0} грн";
                series.Points[index].LabelForeColor = Color.Black;
                series.Points[index].ToolTip =
                    $"Період: {weekStart:dd.MM.yyyy} - {weekEnd:dd.MM.yyyy}\n" +
                    $"Замовлень: {ordersInWeek.Count}\n" +
                    $"Середній чек: {average:0.00} грн";
            }
            chart2.Series.Add(series);
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.AxisY.Minimum = 0;
            area.AxisY.LabelStyle.Format = "0";
            area.Position = new ElementPosition(8, 18, 88, 74);
            area.InnerPlotPosition = new ElementPosition(14, 8, 80, 68);
        }
        private void LoadOrdersByWeeksChart()
        {
            ResetChart(chart2, "Кількість замовлень по місяцях", "", "Кількість");
            var series = CreateSeries("Замовлення", SeriesChartType.Column);
            series.Color = Color.MediumSeaGreen;
            series.IsValueShownAsLabel = true;
            series.IsXValueIndexed = true;
            series["PixelPointWidth"] = "45";
            series["LabelStyle"] = "Top";
            series.SmartLabelStyle.Enabled = false;
            series.Font = new Font("Georgia", 8, FontStyle.Bold);
            var data = _company.Orders
                .Where(o => o.OrderDate != DateTime.MinValue)
                .GroupBy(o => new DateTime(o.OrderDate.Year, o.OrderDate.Month, 1))
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    MonthDate = g.Key,
                    Count = g.Count()
                })
                .ToList();
            foreach (var item in data)
            {
                int index = series.Points.AddY(item.Count);
                series.Points[index].AxisLabel =
                    $"{GetMonthName(item.MonthDate.Month)}\n{item.MonthDate.Year}";
                series.Points[index].Label = item.Count.ToString();
                series.Points[index].LabelForeColor = Color.Black;
                series.Points[index].ToolTip =
                    $"Місяць: {GetMonthName(item.MonthDate.Month)} {item.MonthDate.Year}\n" +
                    $"Кількість замовлень: {item.Count}";
            }
            chart2.Series.Add(series);
            ChartArea area = chart2.ChartAreas[0];
            area.AxisX.Title = "";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.AxisY.Minimum = 0;
            area.AxisY.Interval = 1;
            area.AxisY.LabelStyle.Format = "0";
            double maxValue = series.Points.Count > 0
                ? series.Points.Max(p => p.YValues[0])
                : 0;
            area.AxisY.Maximum = maxValue > 0 ? maxValue + 1 : 4;
            area.Position = new ElementPosition(8, 18, 88, 74);
            area.InnerPlotPosition = new ElementPosition(14, 8, 80, 68);
        }
        private void LoadPaymentChart()
        {
            ResetChart(chart3, "Статистика оплат замовлень", "", "");
            chart3.ChartAreas[0].Position = new ElementPosition(3, 20, 48, 72);
            chart3.ChartAreas[0].InnerPlotPosition = new ElementPosition(5, 5, 90, 90);
            Legend legend = new Legend("Оплати");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Georgia", 8, FontStyle.Regular);
            legend.BackColor = Color.Transparent;
            legend.LegendStyle = LegendStyle.Table;
            legend.TableStyle = LegendTableStyle.Wide;
            legend.IsTextAutoFit = false;
            chart3.Legends.Add(legend);
            var series = CreateSeries("Оплати", SeriesChartType.Doughnut);
            series["DoughnutRadius"] = "55";
            series["PieLabelStyle"] = "Disabled";
            series.IsValueShownAsLabel = false;
            series.Legend = "Оплати";
            AddPiePoint(series, "Оплачено", _company.Orders.Count(o => GetPaymentStatus(o) == "Оплачено"), Color.SeaGreen);
            AddPiePoint(series, "Неоплачено", _company.Orders.Count(o => GetPaymentStatus(o) == "Неоплачено"), Color.Crimson);
            AddPiePoint(series, "Частково", _company.Orders.Count(o => GetPaymentStatus(o) == "Частково сплачено"), Color.Orange);
            AddPiePoint(series, "Очікують", _company.Orders.Count(o => GetPaymentStatus(o) == "Очікує оплати"), Color.MediumPurple);
            chart3.Series.Add(series);
        }
        private void AddPiePoint(Series series, string name, int value, Color color)
        {
            int index = series.Points.AddXY(name, value);
            series.Points[index].Color = color;
            series.Points[index].LegendText = $"{name}: {value}";
            series.Points[index].ToolTip = $"{name}: {value} замовлень";
        }
        private void LoadServicesChart()
        {
            ResetChart(chart4, "Популярність послуг", "", "К-ть замовлень");
            var series = CreateSeries("Послуги", SeriesChartType.Column);
            series.IsValueShownAsLabel = true;
            series.IsXValueIndexed = true;
            series["PixelPointWidth"] = "55";
            series["LabelStyle"] = "Top";
            series.SmartLabelStyle.Enabled = false;
            series.Font = new Font("Georgia", 8, FontStyle.Bold);
            Color[] colors =
            {
                Color.DodgerBlue, Color.MediumSeaGreen, Color.Orange, Color.MediumPurple, Color.Crimson, Color.Teal, Color.Goldenrod,  Color.CornflowerBlue
            };
            var services = _company.Orders
                .Where(o => o.Services != null)
                .SelectMany(o => o.Services.SelectMany(s => new[]
                {
                    s.CategoryService,
                    s.OtherService
                }))
                .Where(s => !string.IsNullOrWhiteSpace(s) && s != "Не обрано")
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    Service = g.Key,
                    Count = g.Count()
                })
                .ToList();
            for (int i = 0; i < services.Count; i++)
            {
                int index = series.Points.AddY(services[i].Count);
                series.Points[index].AxisLabel = (i + 1).ToString();
                series.Points[index].Label = services[i].Count.ToString();
                series.Points[index].LabelForeColor = Color.Black;
                series.Points[index].Color = colors[i % colors.Length];
                series.Points[index].ToolTip =
                    $"Послуга: {services[i].Service}\n" +
                    $"Кількість замовлень: {services[i].Count}";
            }
            chart4.Series.Add(series);
            ChartArea area = chart4.ChartAreas[0];
            area.AxisX.Title = "";
            area.AxisY.Title = "К-ть замовлень";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Bold);
            area.AxisY.Minimum = 0;
            area.AxisY.Interval = 1;
            area.AxisY.LabelStyle.Format = "0";
            double maxValue = series.Points.Count > 0
                ? series.Points.Max(p => p.YValues[0])
                : 0;
            area.AxisY.Maximum = maxValue > 0 ? maxValue + 1 : 4;
            area.Position = new ElementPosition(5, 18, 90, 76);
            area.InnerPlotPosition = new ElementPosition(12, 8, 82, 68);
        }
        private string ShortServiceName(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            return text
                .Replace("Прибирання після ремонту", "Прибирання після\nремонту")
                .Replace("Генеральне прибирання", "Генеральне\nприбирання")
                .Replace("Підтримувальне прибирання", "Підтримувальне\nприбирання")
                .Replace("Прибирання офісу", "Прибирання\nофісу")
                .Replace("Миття вікон", "Миття\nвікон")
                .Replace("Хімчистка диванів", "Хімчистка\nдиванів")
                .Replace("Хімчистка килимів", "Хімчистка\nкилимів")
                .Replace("Полірування паркету", "Полірування\nпаркету")
                .Replace("Чистка м’яких крісел та стільців", "Чистка крісел\nта стільців");
        }
        private void LoadEmployeeChart(Employee emp)
        {
            ResetChart(chart1, "Статистика працівника", "", "Значення");
            chart1.Width = 620;
            chart1.Height = 260;
            var series = CreateSeries("Працівник", SeriesChartType.Column);
            series.Color = Color.SeaGreen;
            series.IsValueShownAsLabel = true;
            series.IsXValueIndexed = true;
            series["PixelPointWidth"] = "60";
            series["LabelStyle"] = "Top";
            series.SmartLabelStyle.Enabled = false;
            series.Font = new Font("Georgia", 8, FontStyle.Bold);
            int orderIndex = series.Points.AddY(emp.GetOrdersCount());
            series.Points[orderIndex].AxisLabel = "Замовлення";
            series.Points[orderIndex].Label = emp.GetOrdersCount().ToString();
            series.Points[orderIndex].ToolTip =
                $"Працівник: {emp.EmployeeName}\nВиконаних замовлень: {emp.GetOrdersCount()}";
            int salaryIndex = series.Points.AddY(emp.GetSalary());
            series.Points[salaryIndex].AxisLabel = "Зарплата";
            series.Points[salaryIndex].Label = $"{emp.GetSalary():0} грн";
            series.Points[salaryIndex].ToolTip =
                $"Працівник: {emp.EmployeeName}\nЗарплата: {emp.GetSalary():0.00} грн";
            chart1.Series.Add(series);
            ChartArea area = chart1.ChartAreas[0];
            area.AxisX.Title = "";
            area.AxisY.Title = "Значення";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Font = new Font("Georgia", 9, FontStyle.Regular);
            area.AxisY.Minimum = 0;
            area.AxisY.LabelStyle.Format = "0";
            double maxValue = series.Points.Max(p => p.YValues[0]);
            area.AxisY.Maximum = maxValue > 0 ? maxValue * 1.25 : 10;
            area.Position = new ElementPosition(5, 18, 90, 76);
            area.InnerPlotPosition = new ElementPosition(14, 8, 80, 68);
        }
        private void ResetChart(Chart chart, string title, string xTitle, string yTitle)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear();
            chart.BackColor = Color.AliceBlue;
            chart.BorderlineColor = Color.DarkSeaGreen;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            Title chartTitle = new Title(title);
            chartTitle.Font = new Font("Georgia", 12, FontStyle.Bold);
            chartTitle.ForeColor = Color.Teal;
            chartTitle.Alignment = ContentAlignment.TopCenter;
            chart.Titles.Add(chartTitle);
            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("ChartArea1"));
            ChartArea area = chart.ChartAreas[0];
            area.BackColor = Color.White;
            area.AxisX.Title = xTitle;
            area.AxisY.Title = yTitle;
            area.AxisX.TitleFont = new Font("Georgia", 9, FontStyle.Regular);
            area.AxisY.TitleFont = new Font("Georgia", 9, FontStyle.Regular);
            area.AxisX.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.Interval = 1;
            area.AxisY.Minimum = 0;
            area.AxisX.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisX.LineColor = Color.Gray;
            area.AxisY.LineColor = Color.Gray;
            area.Position = new ElementPosition(8, 18, 88, 72);
            area.InnerPlotPosition = new ElementPosition(16, 8, 78, 72);
        }
        private Series CreateSeries(string name, SeriesChartType type)
        {
            var series = new Series(name)
            {
                ChartType = type,
                IsValueShownAsLabel = false,
                Font = new Font("Georgia", 8, FontStyle.Bold),
                LabelForeColor = Color.Black
            };
            if (type == SeriesChartType.Column)
                series["PixelPointWidth"] = "45";
            if (type == SeriesChartType.Bar)
                series["PixelPointWidth"] = "28";
            return series;
        }
        private Series CreateSeries(string name)
        {
            return CreateSeries(name, SeriesChartType.Column);
        }
        private void MakeColumnChartPretty(Chart chart)
        {
            ChartArea area = chart.ChartAreas[0];
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.IsLabelAutoFit = false;
            area.AxisX.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.Position = new ElementPosition(8, 18, 88, 74);
            area.InnerPlotPosition = new ElementPosition(14, 8, 80, 68);
        }
        private void MakeBarChartPretty(Chart chart)
        {
            ChartArea area = chart.ChartAreas[0];
            area.AxisY.Title = "";
            area.AxisX.Title = "Кількість замовлень"; 
            area.AxisY.LabelStyle.Angle = 0;
            area.AxisY.IsLabelAutoFit = false;
            area.AxisY.LabelStyle.Font = new Font("Georgia", 8, FontStyle.Regular);
            area.Position = new ElementPosition(5, 18, 92, 74);
            area.InnerPlotPosition = new ElementPosition(34, 8, 58, 72);
        }
        private string ShortEmployeeName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "";
            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
                return parts[0] + "\n" + parts[1];
            return fullName;
        }
        private string ShortText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            return text
                .Replace("Прибирання після ремонту", "Прибирання\nпісля ремонту")
                .Replace("Генеральне прибирання", "Генеральне\nприбирання")
                .Replace("Підтримувальне прибирання", "Підтримувальне\nприбирання")
                .Replace("Прибирання будинку", "Прибирання\nбудинку")
                .Replace("Прибирання котеджу", "Прибирання\nкотеджу")
                .Replace("Прибирання офісу", "Прибирання\nофісу")
                .Replace("Прибирання ресторану", "Прибирання\nресторану")
                .Replace("Прибирання магазинів", "Прибирання\nмагазинів");
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
                "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"
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
        private void LabelIncome_Click(object sender, EventArgs e)
        {
            LoadIncomeByMonthsChart();
        }
        private void LabelAverage_Click(object sender, EventArgs e)
        {
            LoadAverageCheckByWeeksChart();
        }
        private void LabelOrders_Click(object sender, EventArgs e)
        {
            LoadOrdersByWeeksChart();
        }
        private void LabelPayment_Click(object sender, EventArgs e)
        {
            LoadPaymentChart();
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not Employee emp) return;
            label20.Text = emp.GetOrdersCount().ToString();
            label21.Text = $"{emp.GetSalary():0.00} грн";
            LoadEmployeeChart(emp);
        }
    }
}