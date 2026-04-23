using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Клінінгова служба";

            // Прив'язка подій до MenuStrip
            saveMenuItem.Click += saveToolStripButton_Click;
            loadMenuItem.Click += loadToolStripButton_Click;
            exitMenuItem.Click += (s, e) => Application.Exit();

            newPolicyMenuItem.Click += newPolicyToolStripButton_Click_1;
            переглядВсіхToolStripMenuItem.Click += (s, e) => RefreshGrid();
            changeStatusMenuItem.Click += changeStatusToolStripButton_Click;

            statisticsMenuItem.Click += statisticsMenuItem_Click;
            incomeReportMenuItem.Click += incomeReportMenuItem_Click;

            // Фільтрація
            filterAllMenuItem.Click += (s, e) => RefreshGrid();
            filterActiveMenuItem.Click += (s, e) => FilterOrders("Активний");
            filterExpiredMenuItem.Click += (s, e) => FilterOrders("Закінчився");
            filterCancelledMenuItem.Click += (s, e) => FilterOrders("Анульований");

            // Прив'язка подій до ToolStrip
            deletePolicyToolStripButton.Click += deletePolicyToolStripButton_Click;
            editPolicyToolStripButton.Click += editPolicyToolStripButton_Click;
            changeStatusToolStripButton.Click += changeStatusToolStripButton_Click;
            saveToolStripButton.Click += saveToolStripButton_Click;
            loadToolStripButton.Click += loadToolStripButton_Click;

            // Налаштування таблиці
            dataGridView1.AutoGenerateColumns = false;

            InitContextMenu();
            LoadDataOnStartup();
        }

        private void InitContextMenu()
        {
            gridContextMenu = new ContextMenuStrip();
            gridContextMenu.Items.Add("Редагувати", null, editPolicyToolStripButton_Click);
            gridContextMenu.Items.Add("Видалити", null, deletePolicyToolStripButton_Click);
            gridContextMenu.Items.Add(new ToolStripSeparator());
            gridContextMenu.Items.Add("Змінити стан оплати", null, changeStatusToolStripButton_Click);

            dataGridView1.ContextMenuStrip = gridContextMenu;
        }

        private void RefreshGrid(IEnumerable<Order> dataSource = null)
        {
            dataGridView1.DataSource = null;
            var listToDisplay = dataSource ?? company.Orders;
            dataGridView1.DataSource = listToDisplay.ToList();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var order = (Order)row.DataBoundItem;

                // Стовпець 8: Фахівець
                row.Cells["Column8"].Value = order.Employee;

                // Стовпець 4: Послуги
                string mainService = (order.Services != null && order.Services.Count > 0)
                    ? order.Services[0].CategoryService
                    : "Не вказано";

                if (order.Services != null && order.Services.Count > 1)
                {
                    mainService += " + " + order.Services[1].CategoryService;
                }
                row.Cells["Column4"].Value = mainService;

                // Стовпець 6: Стан оплати (у вашому дизайнері Column6 прив'язаний до Status)
                row.Cells["Column6"].Value = order.PaymentStatus;
            }
        }

        private void FilterOrders(string status)
        {
            // Припускаємо, що у класу Order є поле Status для фільтрації
            var filtered = company.Orders.Where(o => o.PaymentStatus == status);
            RefreshGrid(filtered);
        }

        private void LoadDataOnStartup()
        {
            if (File.Exists(path))
            {
                company.ReadFromFile(path);
                RefreshGrid();
            }
        }

        // --- Обробники ---

        private void loadToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "XML файли (*.xml)|*.xml|Усі файли (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        path = ofd.FileName;
                        company.ReadFromFile(path);
                        RefreshGrid();
                        MessageBox.Show("Дані зчитано!", "Успіх");
                    }
                }
                catch
                {
                    MessageBox.Show("Помилка читання файлу!");
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML файли (*.xml)|*.xml";
                sfd.FileName = "orders.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    company.WriteToFile(sfd.FileName);
                    path = sfd.FileName;
                    MessageBox.Show("Дані збережено!", "Успіх");
                }
            }
        }

        private void newPolicyToolStripButton_Click_1(object sender, EventArgs e)
        {
            using (NewClientForm form = new NewClientForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    company.AddOrder(form.NewOrder);
                    RefreshGrid();
                }
            }
        }

        private void editPolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            using (NewClientForm form = new NewClientForm(order))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void deletePolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Видалити замовлення {order.FullNameClient}?", "Увага",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                company.RemoveOrder(order);
                RefreshGrid();
            }
        }

        private void changeStatusToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            // Логіка перемикання статусу оплати
            order.PaymentStatus = (order.PaymentStatus == "Оплачено") ? "Не оплачено" : "Оплачено";
            RefreshGrid();
        }

        private void statisticsMenuItem_Click(object sender, EventArgs e)
        {
            int total = company.Orders.Count;
            int paid = company.Orders.Count(o => o.PaymentStatus == "Оплачено");
            MessageBox.Show($"Всього замовлень: {total}\nОплачено: {paid}", "Статистика");
        }

        private void incomeReportMenuItem_Click(object sender, EventArgs e)
        {
            double income = company.Orders.Sum(o => o.Price);
            MessageBox.Show($"Загальний дохід: {income:F2} грн", "Звіт");
        }
    }
}