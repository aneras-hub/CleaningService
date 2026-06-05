using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            SearchBox.PlaceholderText = "Пошук по ПІБ або номеру";

            InitGrid();
            InitControls();
            RefreshGrid();
            ApplyStyle();
        }

        private void InitGrid()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "BirthDate",
                HeaderText = "Дата народження",
                DataPropertyName = "BirthDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                FillWeight = 90
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeName",
                HeaderText = "ПІБ фахівця",
                DataPropertyName = "EmployeeName",
                FillWeight = 200
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EmployeeNumber",
                HeaderText = "Телефон",
                DataPropertyName = "EmployeeNumber",
                FillWeight = 110
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "OrdersCount",
                HeaderText = "Замовлень",
                FillWeight = 70
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Salary",
                HeaderText = "Зарплата (грн)",
                FillWeight = 100
            });

            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                if (col.Name != "EmployeeName")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            dataGridView.CellFormatting -= DataGridView1_CellFormatting;
            dataGridView.CellFormatting += DataGridView1_CellFormatting;

            dataGridView.DataError -= DataGridView1_DataError;
            dataGridView.DataError += DataGridView1_DataError;
        }

        private void InitControls()
        {

        }

        private void RefreshGrid(IEnumerable<Employee> data = null)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = (data ?? employeeManager.Employees).ToList();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dataGridView.Rows[e.RowIndex].DataBoundItem is Employee emp)
            {
                string columnName = dataGridView.Columns[e.ColumnIndex].Name;

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
        private void ApplyStyle()
        {
            Font mainFont = new Font("Georgia", 10, FontStyle.Regular);

            foreach (Control c in this.Controls)
            {
                c.Font = mainFont;
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
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = SearchBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                RefreshGrid();
            }
            else
            {
                RefreshGrid(employeeManager.Search(search));
            }
        }

        private void NewEmployeeToolStripButton_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Фахівця не створено. Перевірте форму додавання.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (employeeManager.Employees.Any(emp => emp.EmployeeNumber == form.NewEmployee.EmployeeNumber))
                {
                    MessageBox.Show("Працівник з таким номером телефону вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int newId = employeeManager.Employees.Count > 0 ? employeeManager.Employees.Max(emp => emp.Id) + 1 : 1;
                form.NewEmployee.Id = newId;
                employeeManager.AddEmployee(form.NewEmployee);
                RefreshGrid();
                MessageBox.Show("Фахівця успішно додано.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void EditEmployeeToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is Employee employee)
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

                            MessageBox.Show("Працівник з таким номером телефону вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        RefreshGrid();
                    }
                }
            }
        }
        private void DeleteEmployeeToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is Employee employee)
            {
                if (employee.GetOrdersCount() > 0)
                {
                    MessageBox.Show("Неможливо видалити працівника, який має замовлення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show($"Видалити працівника {employee.EmployeeName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    employeeManager.RemoveEmployee(employee.Id);
                    RefreshGrid();
                }
            }
        }
        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JSON файли (*.json)|*.json",
                FileName = "orders.json"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            _company.WriteToFile(sfd.FileName, employeeManager);
            _savePath = sfd.FileName;

            MessageBox.Show("Дані збережено!", "Успіх");
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
                _savePath = ofd.FileName;
                _company.ReadFromFile(_savePath, employeeManager);

                foreach (var order in _company.Orders)
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

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveToolStripButton_Click(sender, e);
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            LoadToolStripButton_Click(sender, e);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewOrderMenuItem_Click(object sender, EventArgs e)
        {
            while (true)
            {
                using NewClientForm form = new NewClientForm(employeeManager);
                form.Owner = this;

                if (form.ShowDialog() != DialogResult.OK)
                    break;
            }
        }
        private void StatisticsMenuItem_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics(employeeManager, _company, _savePath);
            Hide();
            form.ShowDialog();
            Show();
        }
        private void NewEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            NewEmployeeToolStripButton_Click(sender, e);
        }
        private void EditEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            EditEmployeeToolStripButton_Click(sender, e);
        }
        private void DeleteEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployeeToolStripButton_Click(sender, e);
        }

        private void OrderAdministrationMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
} 