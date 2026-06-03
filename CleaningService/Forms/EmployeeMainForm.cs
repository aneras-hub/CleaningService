using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            _company = company;
            _savePath = path;

            BackColor = Color.Honeydew;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управління фахівцями";

            searchBox.PlaceholderText = "Пошук по ПІБ або номеру";

            InitGrid();
            InitControls();
            RefreshGrid();
        }

        private void InitGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BirthDate",
                HeaderText = "Дата народження",
                DataPropertyName = "BirthDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                FillWeight = 90
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeName",
                HeaderText = "ПІБ фахівця",
                DataPropertyName = "EmployeeName",
                FillWeight = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeNumber",
                HeaderText = "Телефон",
                DataPropertyName = "EmployeeNumber",
                FillWeight = 110
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "OrdersCount",
                HeaderText = "Замовлень",
                FillWeight = 70
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Salary",
                HeaderText = "Зарплата (грн)",
                FillWeight = 100
            });

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name != "EmployeeName")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            dataGridView1.CellFormatting -= DataGridView1_CellFormatting;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            dataGridView1.DataError -= DataGridView1_DataError;
            dataGridView1.DataError += DataGridView1_DataError;
        }

        private void InitControls()
        {
            toolStripMenuItem2.Click -= newPolicyToolStripButton_Click;
            toolStripMenuItem2.Click += newPolicyToolStripButton_Click;

            редагуватиФахівцяToolStripMenuItem.Click -= editPolicyToolStripButton_Click;
            редагуватиФахівцяToolStripMenuItem.Click += editPolicyToolStripButton_Click;

            toolStripMenuItem3.Click -= deletePolicyToolStripButton_Click;
            toolStripMenuItem3.Click += deletePolicyToolStripButton_Click;

            exitMenuItem.Click += (s, e) => Close();

            searchBox.TextChanged -= searchBox_TextChanged;
            searchBox.TextChanged += searchBox_TextChanged;

            FormClosing -= EmployeeMainForm_FormClosing;
            FormClosing += EmployeeMainForm_FormClosing;
        }

        private void RefreshGrid(IEnumerable<Employee> data = null)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (data ?? employeeManager.Employees).ToList();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Employee emp)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "OrdersCount")
                {
                    e.Value = emp.GetOrdersCount().ToString();
                    e.FormattingApplied = true;
                }
                else if (columnName == "Salary")
                {
                    e.Value = $"{emp.GetSalary():0.00}";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void OrderAdministrationMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reportsMenuItem_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics(employeeManager, _company, _savePath);
            Hide();
            form.ShowDialog();
            Show();
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
                DialogResult result = form.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                if (form.NewEmployee == null)
                {
                    MessageBox.Show(
                        "Фахівця не створено. Перевірте форму додавання.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (employeeManager.Employees.Any(emp =>
                    emp.EmployeeNumber == form.NewEmployee.EmployeeNumber))
                {
                    MessageBox.Show(
                        "Працівник з таким номером телефону вже існує.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int newId = employeeManager.Employees.Count > 0
                    ? employeeManager.Employees.Max(emp => emp.Id) + 1
                    : 1;

                form.NewEmployee.Id = newId;

                employeeManager.AddEmployee(form.NewEmployee);

                RefreshGrid();

                MessageBox.Show(
                    "Фахівця успішно додано.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void deletePolicyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Employee employee)
            {
                if (employee.GetOrdersCount() > 0)
                {
                    MessageBox.Show(
                        "Неможливо видалити працівника, який має замовлення.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Видалити працівника {employee.EmployeeName}?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

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
                string oldPhone = employee.EmployeeNumber;

                using (NewEmployeeForm form = new NewEmployeeForm(employee))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (employeeManager.Employees.Any(emp =>
                            emp.Id != employee.Id &&
                            emp.EmployeeNumber == employee.EmployeeNumber))
                        {
                            employee.EmployeeNumber = oldPhone;

                            MessageBox.Show(
                                "Працівник з таким номером телефону вже існує.",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }

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
            if (!string.IsNullOrWhiteSpace(_savePath))
            {
                _company?.WriteToFile(_savePath);
            }
        }
    }
}