using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CleaningService
{
    public partial class NewClientForm : Form
    {
        public Order NewOrder { get; set; }
        private bool isEdit = false;
        private OrderEmployee employeeManager;
        public NewClientForm(OrderEmployee manager)
        {
            InitializeComponent();
            employeeManager = manager;

            BackColor = Color.Honeydew;
            StartPosition = FormStartPosition.CenterScreen;

            InitPlaceholders();
            InitComboBoxes();
        }
        private void InitPlaceholders()
        {
            textBox1.PlaceholderText = "Петренко Петра Петрівна";
            textBox2.PlaceholderText = "+380997908190";
            textBox3.PlaceholderText = "вул. Петра, 14";
            textBox4.PlaceholderText = "10";
        }
        private void InitComboBoxes()
        {
            comboBox1.Items.AddRange(new[]
            {
                "Генеральне прибирання"," Підтримувальне прибирання", "Прибирання після ремонту", "Прибирання будинку", "Прибирання котеджу", "Прибирання офісу", "Прибирання ресторану", "Прибирання магазинів"
            });
            comboBox2.DataSource = employeeManager.Employees;
            comboBox2.DisplayMember = "EmployeeName";
            comboBox3.Items.AddRange(new[]
            {
                "Миття вікон", "Хімчистка диванів", "Полірування паркету", "Хімчистка килимів", "Чистка м’яких крісел та стільців"
            });
            comboBox4.Items.AddRange(new[]
            {
                "Частково сплачено", "Оплачено", "Очікує оплати", "Неоплачено"
            });
            comboBox5.Items.AddRange(new[]
            {
                "Ранок", "Обід", "Вечір"
            });
            SetDefault(comboBox1);
            SetDefault(comboBox3);
            SetDefault(comboBox4);
            SetDefault(comboBox5);
        }
        private void SetDefault(ComboBox cb)
        {
            cb.Items.Insert(0, "Не обрано");
            cb.SelectedIndex = 0;
        }
        private bool IsValid()
        {
            string fullName = textBox1.Text.Trim();
            string phone = textBox2.Text.Trim();
            string address = textBox3.Text.Trim();
            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length != 3)
                return ShowError("ПІБ має містити рівно 3 слова: прізвище, ім’я та по батькові.");
            foreach (string part in nameParts)
            {
                if (part.Length < 2)
                    return ShowError("Кожна частина ПІБ повинна містити мінімум 2 символи.");
                foreach (char c in part)
                {
                    if (!char.IsLetter(c) && c != '\'' && c != '’' && c != '-')
                        return ShowError("ПІБ може містити лише літери, дефіс та апостроф.");
                }
            }
            string phonePattern = @"^\+38\s0\d{2}\s\d{3}\s\d{4}$";
            if (!Regex.IsMatch(textBox2.Text.Trim(), phonePattern))
                return ShowError("Телефон у форматі +380 99 790 8190");
            if (string.IsNullOrWhiteSpace(textBox3.Text))
                return ShowError("Введіть адресу.");
            if (comboBox1.SelectedIndex < 0)
                return ShowError("Оберіть тип послуг.");
            if (string.IsNullOrWhiteSpace(address))
                return ShowError("Введіть адресу.");
            if (address.Length < 5)
                return ShowError("Адреса занадто коротка.");
            if (comboBox1.SelectedIndex <= 0)
                return ShowError("Оберіть тип послуги.");
            if (!double.TryParse(textBox4.Text.Trim(), out double area) || area <= 0)
                return ShowError("Площа має бути числом більше 0.");
            if (area > 10000)
                return ShowError("Площа приміщення занадто велика.");
            if (comboBox2.SelectedIndex < 0 || comboBox2.SelectedItem == null)
                return ShowError("Оберіть фахівця.");
            if (comboBox5.SelectedIndex <= 0)
                return ShowError("Оберіть час прибирання.");
            if (comboBox4.SelectedIndex <= 0)
                return ShowError("Оберіть стан оплати.");
            if (dateTimePicker1.Value.Date < DateTime.Today)
                return ShowError("Дата замовлення не може бути в минулому.");
            return true;
        }
        private bool ShowError(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        public NewClientForm(Order order, OrderEmployee manager) : this(manager)
        {
            NewOrder = order;
            isEdit = true;
            textBox1.Text = order.FullNameClient;
            textBox2.Text = order.PhoneNumber;
            textBox3.Text = order.Address;
            textBox4.Text = order.RoomArea.ToString();
            comboBox2.SelectedItem = employeeManager
               .Employees
               .FirstOrDefault(e => e.Id == order.Employee?.Id);
            comboBox4.SelectedItem = order.PaymentStatus;
            comboBox5.SelectedItem = order.TimeSlot;
            if (order.Services?.Count > 0)
            {
                comboBox1.SelectedItem = order.Services[0].CategoryService;
                comboBox3.SelectedItem = order.Services[0].OtherService;
            }
            dateTimePicker1.Value = order.OrderDate;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;
            double area = double.Parse(textBox4.Text);
            var service = new CleaningService(comboBox1.Text, comboBox3.SelectedItem?.ToString() ?? "");
            var services = new List<CleaningService> { service };
            Employee selectedEmployee = (Employee)comboBox2.SelectedItem;
            if (!isEdit)
            {
                NewOrder = new Order(
                    dateTimePicker1.Value,
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    area,
                    services,
                    selectedEmployee,
                    comboBox4.Text,
                    comboBox5.Text
                );
                if (this.Owner is ClientMainForm mainForm)
                {
                    if (!mainForm.AddOrderFromForm(NewOrder)) return;
                }
            }
            else
            {
                NewOrder.FullNameClient = textBox1.Text;
                NewOrder.PhoneNumber = textBox2.Text;
                NewOrder.Address = textBox3.Text;
                NewOrder.RoomArea = area;
                NewOrder.Services = services;
                NewOrder.Employee = selectedEmployee;
                NewOrder.PaymentStatus = comboBox4.Text;
                NewOrder.OrderDate = dateTimePicker1.Value;
                NewOrder.Price = NewOrder.CalculatePrice();
            }
                var result = MessageBox.Show(
                    $"Ціна: {NewOrder.Price} грн\n\nДодати ще клієнта?",
                    "Готово",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    ClearForm();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox4.Text, out double area))
            {
                textBox5.Text = "0 грн"; 
                return;
            }
            double pricePerMeter = comboBox1.Text.Contains("ремонту") ? 180.0 : 100.0;
            textBox5.Text = $"{area * pricePerMeter} грн";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4_TextChanged(null, null);
        }
        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}