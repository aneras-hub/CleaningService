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
            ApplyStyle();
        }
        private void InitPlaceholders()
        {
            NameClient.PlaceholderText = "Петренко Петра Петрівна";
            NumberClient.PlaceholderText = "+38 099 790 8190";
            AdressClient.PlaceholderText = "вул. Петра, 14";
            AreaRoom.PlaceholderText = "10";
        }
        private void InitComboBoxes()
        {
            Posluga.Items.AddRange(new[]
            {
                "Генеральне прибирання","Підтримувальне прибирання", "Прибирання після ремонту", "Прибирання будинку", "Прибирання котеджу", "Прибирання офісу", "Прибирання ресторану", "Прибирання магазинів"
            });
            EmployeeClean.DataSource = employeeManager.Employees;
            EmployeeClean.DisplayMember = "EmployeeName";
            PlusPosluga.Items.AddRange(new[]
            {
                "Миття вікон", "Хімчистка диванів", "Полірування паркету", "Хімчистка килимів", "Чистка м’яких крісел та стільців"
            });
            StanOplatu.Items.AddRange(new[]
            {
                "Частково сплачено", "Оплачено", "Очікує оплати", "Неоплачено"
            });
            TimeCleaning.Items.AddRange(new[]
            {
                "Ранок", "Обід", "Вечір"
            });
            SetDefault(Posluga);
            SetDefault(PlusPosluga);
            SetDefault(StanOplatu);
            SetDefault(TimeCleaning);
        }
        private void ApplyStyle()
        {
            Font mainFont = new Font("Georgia", 12, FontStyle.Regular);
            Font sectionFont = new Font("Georgia", 14, FontStyle.Bold);
            Font titleFont = new Font("Georgia", 20, FontStyle.Bold);
            Font buttonFont = new Font("Georgia", 12, FontStyle.Bold);

            this.Font = mainFont;

            ApplyFontToControls(this, mainFont);

            // Найбільший заголовок
            label1.Font = titleFont;

            // Середні заголовки
            label2.Font = sectionFont;
            label5.Font = sectionFont;

            // Кнопка
            button.Font = buttonFont;
        }
        private void ApplyFontToControls(Control parent, Font font)
        {
            foreach (Control control in parent.Controls)
            {
                control.Font = font;

                if (control.HasChildren)
                    ApplyFontToControls(control, font);
            }
        }
        private void SetDefault(ComboBox cb)
        {
            cb.Items.Insert(0, "Не обрано");
            cb.SelectedIndex = 0;
        }
        private bool IsValid()
        {
            string fullName = NameClient.Text.Trim();
            string phone = NumberClient.Text.Trim();
            string address = AdressClient.Text.Trim();
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
            if (!Regex.IsMatch(NumberClient.Text.Trim(), phonePattern))
                return ShowError("Телефон у форматі +380 99 790 8190");
            if (string.IsNullOrWhiteSpace(AdressClient.Text))
                return ShowError("Введіть адресу.");
            if (Posluga.SelectedIndex < 0)
                return ShowError("Оберіть тип послуг.");
            if (string.IsNullOrWhiteSpace(address))
                return ShowError("Введіть адресу.");
            if (address.Length < 5)
                return ShowError("Адреса занадто коротка.");
            if (Posluga.SelectedIndex <= 0)
                return ShowError("Оберіть тип послуги.");
            if (!double.TryParse(AreaRoom.Text.Trim(), out double area) || area <= 0)
                return ShowError("Площа має бути числом більше 0.");
            if (area > 10000)
                return ShowError("Площа приміщення занадто велика.");
            if (EmployeeClean.SelectedIndex < 0 || EmployeeClean.SelectedItem == null)
                return ShowError("Оберіть фахівця.");
            if (TimeCleaning.SelectedIndex <= 0)
                return ShowError("Оберіть час прибирання.");
            if (StanOplatu.SelectedIndex <= 0)
                return ShowError("Оберіть стан оплати.");
            if (dateTimePicker.Value.Date < DateTime.Today)
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
            NameClient.Text = order.FullNameClient;
            NumberClient.Text = order.PhoneNumber;
            AdressClient.Text = order.Address;
            AreaRoom.Text = order.RoomArea.ToString();
            EmployeeClean.SelectedItem = employeeManager
               .Employees
               .FirstOrDefault(e => e.Id == order.Employee?.Id);
            StanOplatu.SelectedItem = order.PaymentStatus;
            TimeCleaning.SelectedItem = order.TimeSlot;
            if (order.Services?.Count > 0)
            {
                Posluga.SelectedItem = order.Services[0].CategoryService;
                PlusPosluga.SelectedItem = order.Services[0].OtherService;
            }
            dateTimePicker.Value = order.OrderDate;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;
            double area = double.Parse(AreaRoom.Text);
            var service = new CleaningService(Posluga.Text, PlusPosluga.SelectedItem?.ToString() ?? "");
            var services = new List<CleaningService> { service };
            Employee selectedEmployee = (Employee)EmployeeClean.SelectedItem;
            if (!isEdit)
            {
                NewOrder = new Order(
                    dateTimePicker.Value,
                    NameClient.Text,
                    NumberClient.Text,
                    AdressClient.Text,
                    area,
                    services,
                    selectedEmployee,
                    StanOplatu.Text,
                    TimeCleaning.Text
                );
                if (this.Owner is ClientMainForm mainForm)
                {
                    if (!mainForm.AddOrderFromForm(NewOrder)) return;
                }
            }
            else
            {
                NewOrder.FullNameClient = NameClient.Text;
                NewOrder.PhoneNumber = NumberClient.Text;
                NewOrder.Address = AdressClient.Text;
                NewOrder.RoomArea = area;
                NewOrder.Services = services;
                NewOrder.Employee = selectedEmployee;
                NewOrder.PaymentStatus = StanOplatu.Text;
                NewOrder.OrderDate = dateTimePicker.Value;
                NewOrder.TimeSlot = TimeCleaning.Text;
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
            if (!double.TryParse(AreaRoom.Text, out double area))
            {
                textBox5.Text = "0 грн"; 
                return;
            }
            double pricePerMeter = Posluga.Text.Contains("ремонту") ? 180.0 : 100.0;
            textBox5.Text = $"{area * pricePerMeter} грн";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4_TextChanged(null, null);
        }
        private void ClearForm()
        {
            NameClient.Clear();
            NumberClient.Clear();
            AdressClient.Clear();
            AreaRoom.Clear();
            Posluga.SelectedIndex = 0;
            if (EmployeeClean.Items.Count > 0)
                EmployeeClean.SelectedIndex = 0;
            PlusPosluga.SelectedIndex = 0;
            StanOplatu.SelectedIndex = 0;
            TimeCleaning.SelectedIndex = 0;
            dateTimePicker.Value = DateTime.Now;
        }
    }
}