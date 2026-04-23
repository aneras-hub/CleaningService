using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace CleaningService
{
    public partial class NewClientForm : Form
    {
        public Order NewOrder { get; set; }
        private bool isEdit = false;

        // --- КОНСТРУКТОР (СТВОРЕННЯ) ---
        public NewClientForm()
        {
            InitializeComponent();
            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBox1.Items.AddRange(new string[]
            {
                "Генеральне прибирання",
                "Підтримувальне прибирання",
                "Прибирання після ремонту",
                "Прибирання будинку",
                "Прибирання котеджу",
                "Прибирання офісу",
                "Прибирання ресторану",
                "Прибирання магазинів"
            });
            comboBox2.Items.AddRange(new string[]
            {
                "Вербицький Артем Олександрович",
                "Зима Марія Віталіївна",
                "Мельниченко Владислав Ігорович",
                "Озерська Анна Костянтинівна",
                "Яворівський Максим Юрійович"
            });
            comboBox3.Items.AddRange(new string[]
            {
                "Миття вікон",
                "Хімчистка диванів",
                "Полірування паркету",
                "Хімчистка килимів",
                "Чистка м’яких крісел та стільців"
            });
            comboBox4.Items.AddRange(new string[]
            {
                "Частково сплачено",
                "Оплачено",
                "Очікує оплати",
                "Неоплачено"
            });
        }
        private bool IsValid()
        {
            // Перевірка ПІБ
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть ПІБ клієнта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Перевірка Номера телефону
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Будь ласка, введіть номер телефону.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Перевірка Адреси
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Будь ласка, введіть адресу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Перевірка Послуги
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, вкажіть тип послуг.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Перевірка Площі
            if (!double.TryParse(textBox4.Text, out double area) || area <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректну площу приміщення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Перевірка Фахівця
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, вкажіть відповідального фахівця.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Перевірка Стану оплати
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, вкажіть стан оплати.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // --- КОНСТРУКТОР (РЕДАГУВАННЯ) ---
        public NewClientForm(Order order) : this()
        {
            NewOrder = order;
            isEdit = true;

            textBox1.Text = order.FullNameClient;
            textBox2.Text = order.PhoneNumber;
            textBox3.Text = order.Address;
            textBox4.Text = order.RoomArea.ToString();
            comboBox2.SelectedItem = order.Employee;
            comboBox4.SelectedItem = order.PaymentStatus;

            if (order.Services != null && order.Services.Count > 0)
            {
                comboBox1.SelectedItem = order.Services[0].CategoryService;
                comboBox3.SelectedItem = order.Services[0].OtherService;
            }

            dateTimePicker1.Value = order.OrderDate;
        }

        // --- КНОПКА OK ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            var service = new CleaningService(
                comboBox1.Text,
                comboBox3.SelectedItem?.ToString() ?? ""
            );

            var services = new List<CleaningService> { service };

            if (!isEdit)
            {
                NewOrder = new Order(
                    dateTimePicker1.Value,
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    double.Parse(textBox4.Text),
                    services,
                    comboBox2.Text,
                    comboBox4.Text
                );
            }
            else
            {
                NewOrder.FullNameClient = textBox1.Text;
                NewOrder.PhoneNumber = textBox2.Text;
                NewOrder.Address = textBox3.Text;
                NewOrder.RoomArea = double.Parse(textBox4.Text);
                NewOrder.Services = services;
                NewOrder.Employee = comboBox2.Text;
                NewOrder.PaymentStatus = comboBox4.Text;
                NewOrder.OrderDate = dateTimePicker1.Value;

                NewOrder.Price = NewOrder.CalculatePrice();
            }
            MessageBox.Show($"Ціна: {NewOrder.Price} грн");
            DialogResult = DialogResult.OK;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox4.Text, out double area))
            {
                double pricePerMeter = comboBox1.Text.Contains("ремонту") ? 180.0 : 100.0;
                textBox5.Text = (area * pricePerMeter).ToString() + " грн";
            }
            else
            {
                textBox5.Text = "0 грн";
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4_TextChanged(null, null);
        }

    }
}