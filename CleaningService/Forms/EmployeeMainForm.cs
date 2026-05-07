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

            // ПРАВИЛЬНЕ ПРИСВОЄННЯ:
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

            InitGrid();
            InitControls();
            RefreshGrid();

        }
        private void InitGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Дата народження
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Дата народження",
                DataPropertyName = "BirthDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }, // Формат 27.10.1988
                Width = 120
            });
            // ПІБ
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ПІБ фахівця",
                DataPropertyName = "EmployeeName",
                Width = 250
            });

            // Телефон
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Телефон",
                DataPropertyName = "EmployeeNumber",
                Width = 150
            });

            // Кількість замовлень (Розрахункове поле)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Замовлень",
                Name = "OrdersCount",
                Width = 100
            });

            // Зарплата (Розрахункове поле)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Зарплата (грн)",
                Name = "Salary",
                Width = 120
            });

            // Налаштування вигляду
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Центрування тексту в колонках
            dataGridView1.Columns["OrdersCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Salary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
