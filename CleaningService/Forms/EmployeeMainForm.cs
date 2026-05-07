using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleaningService.Forms
{
    public partial class EmployeeMainForm : Form
    {
        private OrderEmployee employeeManager;
        private CleaningCompany _company;
        private string _savePath;
        public EmployeeMainForm(OrderEmployee manager, CleaningCompany company, string path)
        {
            InitializeComponent();
            employeeManager = manager ?? new OrderEmployee();

            //ПРИСВОЄННЯ:
            this._company = company;
            this._savePath = path;

            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Управління фахівцями";

            searchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            //щоб текст в колонках автоматично підлаштовувався
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // посередині текст
            dataGridView1.Columns["EmployeeNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["EmployeeSalary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["CompletedOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Дозволяє міняти стиль заголовків
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Ivory;
            InitGrid();
            InitControls();
            RefreshGrid();

        }
        private void InitGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // 1. Створення колонок
            // Дата народження
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BirthDate",
                HeaderText = "Дата народження",
                DataPropertyName = "BirthDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                FillWeight = 90 // трохи вужча
            });

            // ПІБ
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeName",
                HeaderText = "ПІБ фахівця",
                DataPropertyName = "EmployeeName",
                FillWeight = 200 // найширша колонка
            });

            // Телефон
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeNumber",
                HeaderText = "Телефон",
                DataPropertyName = "EmployeeNumber",
                FillWeight = 110
            });

            // Кількість замовлень
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Замовлень",
                Name = "OrdersCount",
                FillWeight = 70 // вузька колонка для цифр
            });

            // Зарплата
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Зарплата (грн)",
                Name = "Salary",
                FillWeight = 100
            });

            // 2. Налаштування глобального вигляду
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Розтягування на всю ширину вікна
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 3. Стилізація заголовків (щоб працював колір та вирівнювання)
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            // 4. Центрування вмісту клітинок (крім ПІБ)
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name != "EmployeeName")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // 5. Підписка на події (якщо ще не підписані в дизайнері)
            dataGridView1.CellFormatting -= DataGridView1_CellFormatting; // запобігаємо дублюванню
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }
        private void InitControls()
        {
            // Прив'язка пунктів меню до існуючих методів
            toolStripMenuItem2.Click += newPolicyToolStripButton_Click;        // Новий фахівець
            редагуватиФахівцяToolStripMenuItem.Click += editPolicyToolStripButton_Click; // Редагувати
            toolStripMenuItem3.Click += deletePolicyToolStripButton_Click;      // Видалити

            // Файл
            exitMenuItem.Click += (s, e) => this.Close();

            // Пошук в реальному часі через TextBox
            searchBox.TextChanged += searchBox_TextChanged;

            this.FormClosing += EmployeeMainForm_FormClosing;
        }
        private void RefreshGrid(IEnumerable<Employee> data = null)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (data ?? employeeManager.Employees).ToList();
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Employee emp)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "OrdersCount")
                    e.Value = emp.GetOrdersCount();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Salary")
                    e.Value = emp.GetSalary().ToString("F2");
            }
        }
        private void OrderEmployeeMenuItem_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Employee emp)
            {
                var result = MessageBox.Show($"Видалити працівника {emp.EmployeeName}?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    employeeManager.RemoveEmployee(emp.Id);
                    RefreshGrid();
                }
            }
        }


        private void OrderAdministrationMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportsMenuItem_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics(employeeManager, _company, _savePath);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = searchBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(search))
            {
                RefreshGrid();
            }
            else
            {
                RefreshGrid(employeeManager.Search(search));
            }
        }

        private void newPolicyToolStripButton_Click(object sender, EventArgs e)
        {
            using (NewEmployeeForm form = new NewEmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    employeeManager.AddEmployee(form.NewEmployee);
                    RefreshGrid();
                }
            }
        }

        private void deletePolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Employee employee)
            {
                var result = MessageBox.Show($"Видалити працівника {employee.EmployeeName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    employeeManager.RemoveEmployee(employee.Id);
                    RefreshGrid();
                }
            }
        }

        private void editPolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Employee employee)
            {
                using (NewEmployeeForm form = new NewEmployeeForm(employee))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        RefreshGrid();

                    }
                }
            }
        }

        private void searchBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void EmployeeMainForm_FormClosing(object sender, EventArgs e)
        {
            // Викликаємо збереження в файл автоматично
            _company?.WriteToFile(_savePath);
        }
    }
}
