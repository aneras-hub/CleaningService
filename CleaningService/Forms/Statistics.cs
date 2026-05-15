using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CleaningService.Forms
{
    // якщо замовлення 10 , то оплата має бути вже 9

    public partial class Statistics : Form
    {
        private OrderEmployee employeeManager;
        private CleaningCompany _company;
        private string _savePath;
        public Statistics(OrderEmployee manager, CleaningCompany company, string path)
        {
            InitializeComponent();
            this.Load += Statistics_Load;
            this.employeeManager = manager;
            this._company = company;
            this._savePath = path;
            this.employeeManager = manager;
            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;
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
        private void SetThinColumns(Series series)
        {
            // Встановлюємо фіксовану ширину в пікселях. 
            series["PixelPointWidth"] = "35";
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
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void OrderAdministrationMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadGeneralStatistics()
        {
            double totalIncome = _company.GetTotalIncome();

            int totalOrders = _company.Orders.Count;

            double averageCheck = 0;

            if (totalOrders > 0)
                averageCheck = totalIncome / totalOrders;

            label10.Text = totalIncome.ToString("0") + " грн";
            label11.Text = averageCheck.ToString("0") + " грн";
            label12.Text = totalOrders.ToString();
        }
        private void LoadEmployeeStatistics()
        {
            comboBox1.Items.Clear();

            foreach (var emp in employeeManager.Employees)
            {
                comboBox1.Items.Add(emp);
            }

            comboBox1.DisplayMember = "EmployeeName";

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee emp = comboBox1.SelectedItem as Employee;

            if (emp == null)
                return;

            label20.Text = emp.GetOrdersCount().ToString();

            label21.Text = emp.GetSalary().ToString("0") + " грн";

            LoadEmployeeChart(emp);
        }
        private void LoadEmployeeChart(Employee emp)
        {
            chart1.Series.Clear();
            Series series = CreateSeries();
            series.Points.AddXY("Замовлення", emp.GetOrdersCount());

            series.Points.AddXY("Зарплата", emp.GetSalary());
            SetThinColumns(series);
            chart1.Series.Add(series);
        }
        private void LoadCharts()
        {
            LoadIncomeChart();
            LoadPaymentChart();
            LoadServicesChart();
            LoadEmployeesChart();
        }
        private void LoadIncomeChart()
        {
            chart2.Series.Clear();
            Series series = CreateSeries();
            series.Points.AddXY("Дохід служби", _company.GetTotalIncome());
            SetThinColumns(series);
            chart2.Series.Add(series);
        }
        private void LoadPaymentChart()
        {
            chart3.Series.Clear();
            Series series = CreateSeries();

            series.Points.AddXY(
                "Оплачено",
                _company.Orders.Count(o => o.PaymentStatus == "Оплачено"));

            series.Points.AddXY(
                "Неоплачено",
                _company.Orders.Count(o => o.PaymentStatus == "Неоплачено"));

            series.Points.AddXY(
                "Частково",
                _company.Orders.Count(o => o.PaymentStatus == "Частково сплачено"));

            series.Points.AddXY(
                "Очікує",
                _company.Orders.Count(o => o.PaymentStatus == "Очікує оплати"));
            SetThinColumns(series);
            chart3.Series.Add(series);
        }
        private void LoadServicesChart()
        {
            chart4.Series.Clear();
            Series series = CreateSeries();

            var services = _company.Orders
                .SelectMany(o => o.Services)
                .GroupBy(s => s.CategoryService)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                });

            foreach (var s in services)
            {
                series.Points.AddXY(s.Name, s.Count);
            }
            SetThinColumns(series);
            chart4.Series.Add(series);
        }
        private void LoadEmployeesChart()
        {
            chart5.Series.Clear();
            Series series = CreateSeries();

            foreach (var emp in employeeManager.GetTopEmployees())
            {
                series.Points.AddXY(
                    emp.EmployeeName,
                    emp.GetOrdersCount());
            }
            SetThinColumns(series);
            chart5.Series.Add(series);
        }
        private void LoadPaymentStatistics()
        {
            int paid = _company.Orders.Count(o => o.PaymentStatus == "Оплачено");
            int unpaid = _company.Orders.Count(o => o.PaymentStatus == "Неоплачено");
            int partial = _company.Orders.Count(o => o.PaymentStatus == "Частково сплачено");
            int waiting = _company.Orders.Count(o => o.PaymentStatus == "Очікує оплати");

            label13.Text = paid.ToString();
            label14.Text = unpaid.ToString();
            label15.Text = partial.ToString();
            label16.Text = waiting.ToString();
        }
        private void LabelIncome_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            label10.ForeColor = Color.Green;
            chart2.Series.Clear();
            Series series = CreateSeries();
            series.Points.AddXY("Дохід", _company.GetTotalIncome());
            SetThinColumns(series);
            chart2.Series.Add(series);
        }
        private void LabelAverage_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            label11.ForeColor = Color.Green;
            double avg = 0;

            if (_company.Orders.Count > 0)
            {
                avg = _company.GetTotalIncome() / _company.Orders.Count;
            }
            Series series = CreateSeries();

            series.Points.AddXY("Середній чек", avg);
            SetThinColumns(series);
            chart2.Series.Add(series);
        }
        private void LabelOrders_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            label12.ForeColor = Color.Green;
            Series series = CreateSeries();

            series.Points.AddXY("Замовлення", _company.Orders.Count);
            SetThinColumns(series);
            chart2.Series.Add(series);
        }
        private void LabelPayment_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            label13.ForeColor = Color.Green;
            Series series = CreateSeries();

            series.Points.AddXY(
                "Оплачено",
                _company.Orders.Count(o => o.PaymentStatus == "Оплачено"));

            series.Points.AddXY(
                "Неоплачено",
                _company.Orders.Count(o => o.PaymentStatus == "Неоплачено"));

            series.Points.AddXY(
                "Частково",
                _company.Orders.Count(o => o.PaymentStatus == "Частково сплачено"));

            series.Points.AddXY(
                "Очікує",
                _company.Orders.Count(o => o.PaymentStatus == "Очікує оплати"));
            SetThinColumns(series);
            chart2.Series.Add(series);
        }
            private void ResetLabelColors()
        {
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;

            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label16.ForeColor = Color.Black;
        }
        private Series CreateSeries()
        {
            Series series = new Series();

            series.ChartType = SeriesChartType.Column;

            series.IsValueShownAsLabel = true;

            SetThinColumns(series);

            return series;
        }
    }
}
