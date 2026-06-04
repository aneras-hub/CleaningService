using CleaningService.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;


namespace CleaningService
{
    public partial class ClientMainForm : Form
    {
        private CleaningCompany company = new CleaningCompany();
        private string path = "orders.json";
        private ContextMenuStrip gridContextMenu;
        private OrderEmployee employeeManager = new OrderEmployee();

        public ClientMainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Клінінгова служба";

            InitMenu();
            InitToolStrip();
            InitGrid();
            InitContextMenu();
            InitEmployees();
            ApplyStyle();

            SearchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";

            LoadDataOnStartup();
        }

        private void InitMenu()
        {
            fAllMenuItem.Click += (s, e) => RefreshGrid();
            fOplachenoMenuItem.Click += (s, e) => FilterOrders("Оплачено");
            fHalfOplatchenoMenuItem.Click += (s, e) => FilterOrders("Частково сплачено");
            fWaitOplataMenuItem.Click += (s, e) => FilterOrders("Очікує оплати");
            fAnyOplataMenuItem.Click += (s, e) => FilterOrders("Неоплачено");
        }

        private void InitToolStrip()
        {
        }

        private void InitGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Gray;

            dataGridView1.Columns["Column1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column7"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Column8"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void InitContextMenu()
        {
            gridContextMenu = new ContextMenuStrip();
            gridContextMenu.Items.Add("Редагувати", null, EditOrderToolStripButton_Click);
            gridContextMenu.Items.Add("Видалити", null, DeleteOrderToolStripButton_Click);

            dataGridView1.ContextMenuStrip = gridContextMenu;
        }

        private void InitEmployees()
        {
            employeeManager.AddEmployee(new Employee(1, "Вербицький Артем Олександрович", "+38 099 000 0001", new DateTime(1988, 10, 27)));
            employeeManager.AddEmployee(new Employee(2, "Зима Марія Віталіївна", "+38 099 000 0002", new DateTime(1995, 3, 12)));
            employeeManager.AddEmployee(new Employee(3, "Мельниченко Владислав Ігорович", "+38 099 000 0003", new DateTime(1992, 7, 5)));
            employeeManager.AddEmployee(new Employee(4, "Озерська Анна Костянтинівна", "+38 099 000 0004", new DateTime(1998, 12, 18)));
            employeeManager.AddEmployee(new Employee(5, "Яворівський Максим Юрійович", "+38 099 000 0005", new DateTime(1991, 1, 30)));
        }

        private void ApplyStyle()
        {
            Font mainFont = new Font("Georgia", 10, FontStyle.Regular);

            foreach (Control c in Controls)
            {
                c.Font = mainFont;
            }
        }
        // таблиця
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
                row.Cells["Column8"].Value =
                    order.Employee != null ? order.Employee.EmployeeName : "Не призначено";

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
            foreach (var order in company.Orders)
            {
                var emp = employeeManager.Employees
                    .FirstOrDefault(e => e.EmployeeName == order.Employee?.EmployeeName);

                if (emp != null)
                {
                    order.Employee = emp;
                    emp.Orders.Add(order);
                }
            }

            RefreshGrid();
        }
        private void LoadToolStripButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "JSON файли (*.json)|*.json|Усі файли (*.*)|*.*"
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
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            LoadToolStripButton_Click(sender, e);
        }
        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JSON файли (*.json)|*.json",
                FileName = "orders.json"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            company.WriteToFile(sfd.FileName);
            path = sfd.FileName;

            MessageBox.Show("Дані збережено!", "Успіх");
        }
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveToolStripButton_Click(sender, e);
        }
        //створення нового замовлення
        private void NewOrderToolStripButton_Click(object sender, EventArgs e)
        {
            while (true)
            {
                using NewClientForm form = new NewClientForm(employeeManager);
                form.Owner = this;

                if (form.ShowDialog() != DialogResult.OK)
                    break;
            }
        }
        private void NewOrderMenuItem_Click(object sender, EventArgs e)
        {
            NewOrderToolStripButton_Click(sender, e);
        }
        //редагування вибраного замовлення
        private void EditOrderToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            using NewClientForm form = new NewClientForm(order, employeeManager);

            if (form.ShowDialog() == DialogResult.OK)
                RefreshGrid();
        }
        private void EditOrdertoolStrip_Click(object sender, EventArgs e)
        {
            EditOrderToolStripButton_Click(sender, e);
        }
        // видалення вибраного замовлення
        private void DeleteOrderToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            if (MessageBox.Show(
                $"Видалити замовлення {order.FullNameClient}?",
                "Увага",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            if (order.Employee != null)
                order.Employee.Orders.Remove(order);

            company.RemoveOrder(order);
            RefreshGrid();
        }
        private void DeletetoolStrip_Click(object sender, EventArgs e)
        {
            DeleteOrderToolStripButton_Click(sender, e);
        }
        //зміна статусу оплати
        private void ChangeOplataToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Оберіть замовлення!");
                return;
            }

            Order order = (Order)dataGridView1.CurrentRow.DataBoundItem;

            ChangePayment form = new ChangePayment(order);

            if (form.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Refresh();
            }
        }
        // підсвічування неоплачених замовлень
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
        // метод для додавання замовлення з форми, який повертає false, якщо не вдалося додати через зайнятість слоту або перевищення ліміту замовлень на день
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
                return false;
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

        // пошук за ПІБ клієнта
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
        // пошук в реальному часі
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string search = SearchBox.Text.Trim().ToLower();

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
                     o.Employee.EmployeeName.ToLower().Contains(search)) ||

                    // Статус
                    (o.PaymentStatus != null &&
                     o.PaymentStatus.ToLower().Contains(search))
                )
                .ToList();

            RefreshGrid(filtered);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Ви дійсно хочете вийти?\nУсі незбережені зміни будуть втрачені.",
                    "Підтвердження виходу",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3 // Фокус на "Скасувати" для безпеки
                );

            if (result == DialogResult.Yes)
            {
                // Користувач хоче зберегти і вийти
                company.WriteToFile(path);
            }
            else if (result == DialogResult.No)
            {
                // Користувач хоче вийти БЕЗ збереження — форма закриється сама
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private void OrderEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMainForm form = new EmployeeMainForm(employeeManager, company, path);

            this.Hide();
            form.ShowDialog();
            this.Show();
            RefreshGrid();
        }
        private void ClientMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void StatisticsMenuItem_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics(employeeManager, company, path);

            Hide();
            form.ShowDialog();
            Show();
        }
    }
}