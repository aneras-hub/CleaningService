using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CleaningService
{
    public partial class ClientMainForm : Form
    {
        private CleaningCompany company = new CleaningCompany();
        private string path = "orders.xml";
        private ContextMenuStrip gridContextMenu;

        public ClientMainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Клінінгова служба";

            InitMenu();
            InitToolStrip();
            InitGrid();
            InitContextMenu();
            searchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            //щоб текст в колонках автоматично підлаштовувався
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // посередині текст
            dataGridView1.Columns["Column3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            LoadDataOnStartup();
        }

        private void InitMenu()
        {
            saveMenuItem.Click += saveToolStripButton_Click;
            loadMenuItem.Click += loadToolStripButton_Click;
            exitMenuItem.Click += (s, e) => Application.Exit();

            newPolicyMenuItem.Click += newPolicyToolStripButton_Click_1;
            changeStatusMenuItem.Click += editPolicyToolStripButton_Click;

            statisticsMenuItem.Click += statisticsMenuItem_Click;
            incomeReportMenuItem.Click += incomeReportMenuItem_Click;

            filterAllMenuItem.Click += (s, e) => RefreshGrid();
            filterActiveMenuItem.Click += (s, e) => FilterOrders("Оплачено");
            filterExpiredMenuItem.Click += (s, e) => FilterOrders("Частково сплачено");
            очікуєОплатиToolStripMenuItem.Click += (s, e) => FilterOrders("Очікує оплати");
            filterCancelledMenuItem.Click += (s, e) => FilterOrders("Неоплачено");
        }

        private void InitToolStrip()
        {
            deletePolicyToolStripButton.Click += deletePolicyToolStripButton_Click;
            editPolicyToolStripButton.Click += editPolicyToolStripButton_Click;
            saveToolStripButton.Click += saveToolStripButton_Click;
            loadToolStripButton.Click += loadToolStripButton_Click;
        }

        private void InitGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
        }

        private void InitContextMenu()
        {
            gridContextMenu = new ContextMenuStrip();
            gridContextMenu.Items.Add("Редагувати", null, editPolicyToolStripButton_Click);
            gridContextMenu.Items.Add("Видалити", null, deletePolicyToolStripButton_Click);

            dataGridView1.ContextMenuStrip = gridContextMenu;
        }

        private void RefreshGrid(IEnumerable<Order> data = null)
        {
            foreach (var order in company.Orders)
            {
                if (order.PaymentStatus == "Очікує оплати" &&
                    DateTime.Now.Date > order.OrderDate.Date)
                {
                    order.PaymentStatus = "Неоплачено";
                }
            }

            var list = (data ?? company.Orders).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void FillExtraColumns()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is not Order order) continue;

                // Фахівець
                row.Cells["Column8"].Value = order.Employee ?? "Не призначено";

                // Послуги
                if (order.Services?.Count > 0)
                {
                    var service = order.Services[0];
                    string text = service.CategoryService;

                    if (!string.IsNullOrEmpty(service.OtherService) &&
                        service.OtherService != "Не обрано")
                    {
                        text += $" (+{service.OtherService})";
                    }

                    row.Cells["Column4"].Value = text;
                }
                else
                {
                    row.Cells["Column4"].Value = "Не вказано";
                }
            }
        }

        private void FilterOrders(string status)
        {
            RefreshGrid(company.FilterByStatus(status));
        }
        private void LoadDataOnStartup()
        {
            if (!File.Exists(path)) return;

            company.ReadFromFile(path);
            RefreshGrid();
        }

        // --- ОБРОБНИКИ ---

        private void loadToolStripButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "XML файли (*.xml)|*.xml|Усі файли (*.*)|*.*"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                path = ofd.FileName;
                company.ReadFromFile(path);

                foreach (var order in company.Orders)
                {
                    order.Services ??= new List<CleaningService>();
                    order.Price = order.CalculatePrice();
                }

                RefreshGrid();
                MessageBox.Show("Дані зчитано!", "Успіх");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка читання:\n{ex.Message}");
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "XML файли (*.xml)|*.xml",
                FileName = "orders.xml"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            company.WriteToFile(sfd.FileName);
            path = sfd.FileName;

            MessageBox.Show("Дані збережено!", "Успіх");
        }

        private void newPolicyToolStripButton_Click_1(object sender, EventArgs e)
        {
            while (true)
            {
                using NewClientForm form = new NewClientForm();
                form.Owner = this;

                if (form.ShowDialog() != DialogResult.OK)
                    break;
            }
        }

        private void editPolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            using NewClientForm form = new NewClientForm(order);

            if (form.ShowDialog() == DialogResult.OK)
                RefreshGrid();
        }

        private void deletePolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            if (MessageBox.Show(
                $"Видалити замовлення {order.FullNameClient}?",
                "Увага",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            company.RemoveOrder(order);
            RefreshGrid();
        }

        private void statisticsMenuItem_Click(object sender, EventArgs e)
        {
            int total = company.Orders.Count;
            int paid = company.Orders.Count(o => o.PaymentStatus == "Оплачено");

            MessageBox.Show($"Всього: {total}\nОплачено: {paid}", "Статистика");
        }

        private void incomeReportMenuItem_Click(object sender, EventArgs e)
        {
            double income = company.Orders.Sum(o => o.Price);
            MessageBox.Show($"Дохід: {income:F2} грн", "Звіт");
        }

        private void changeStatusToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            order.PaymentStatus = order.PaymentStatus == "Оплачено"
                ? "Неоплачено"
                : "Оплачено";

            RefreshGrid();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FillExtraColumns();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Order order)
                {
                    if (order.PaymentStatus == "Неоплачено")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }
        public bool AddOrderFromForm(Order order)
        {
            // перевірка зайнятості слоту
            bool isBusy = company.Orders.Any(o =>
                o.Employee == order.Employee &&
                o.OrderDate.Date == order.OrderDate.Date &&
                o.TimeSlot == order.TimeSlot);

            if (isBusy)
            {
                MessageBox.Show("У цього фахівця цей час вже зайнятий!", "Помилка");
                return false; // 🔥 ВАЖЛИВО
            }

            // перевірка 3 замовлення на день
            int countPerDay = company.Orders.Count(o =>
                o.Employee == order.Employee &&
                o.OrderDate.Date == order.OrderDate.Date);

            if (countPerDay >= 3)
            {
                MessageBox.Show("На цього фахівця вже є 3 замовлення!", "Помилка");
                return false;
            }

            company.AddOrder(order);
            RefreshGrid();

            return true;
        }
        private void SearchMenuItem_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Введіть ПІБ клієнта:",
                "Пошук",
                ""
            );

            if (string.IsNullOrWhiteSpace(name)) return;

            var result = company.FindByClient(name);

            if (result.Count == 0)
            {
                MessageBox.Show("Нічого не знайдено");
                return;
            }

            RefreshGrid(result);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = searchBox.Text.Trim().ToLower();

            var filtered = company.Orders
                .Where(o =>
                    string.IsNullOrEmpty(search) ||

                    // ПІБ клієнта
                    (o.FullNameClient != null &&
                     o.FullNameClient.ToLower().Contains(search)) ||

                    // Телефон
                    (o.PhoneNumber != null &&
                     o.PhoneNumber.ToLower().Contains(search)) ||

                    // Фахівець
                    (o.Employee != null &&
                     o.Employee.ToLower().Contains(search)) ||

                    // Статус
                    (o.PaymentStatus != null &&
                     o.PaymentStatus.ToLower().Contains(search))
                )
                .ToList();

            RefreshGrid(filtered);
        }
    }
}