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

        public NewClientForm()
        {
            InitializeComponent();

            BackColor = Color.Honeydew;
            StartPosition = FormStartPosition.CenterScreen;

            InitPlaceholders();
            InitComboBoxes();
        }

        private void InitPlaceholders()
        {
            textBox1.PlaceholderText = "Петренко Петра Петрівна";
            textBox2.PlaceholderText = "+380 99 790 8190";
            textBox3.PlaceholderText = "вул. Петра, 14";
            textBox4.PlaceholderText = "10";
        }

        private void InitComboBoxes()
        {
            comboBox1.Items.AddRange(new[]
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

            comboBox2.Items.AddRange(new[]
            {
                "Вербицький Артем Олександрович",
                "Зима Марія Віталіївна",
                "Мельниченко Владислав Ігорович",
                "Озерська Анна Костянтинівна",
                "Яворівський Максим Юрійович"
            });

            comboBox3.Items.AddRange(new[]
            {
                "Миття вікон",
                "Хімчистка диванів",
                "Полірування паркету",
                "Хімчистка килимів",
                "Чистка м’яких крісел та стільців"
            });

            comboBox4.Items.AddRange(new[]
            {
                "Частково сплачено",
                "Оплачено",
                "Очікує оплати",
                "Неоплачено"
            });

            comboBox5.Items.AddRange(new[]
            {
                "Ранок",
                "Обід",
                "Вечір"
            });

            SetDefault(comboBox1);
            SetDefault(comboBox2);
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
            // ПІБ
            var nameParts = textBox1.Text.Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length != 3)
                return ShowError("ПІБ має містити рівно 3 слова.");

            // Телефон
            string phonePattern = @"^\+380\s\d{2}\s\d{3}\s\d{4}$";
            if (!Regex.IsMatch(textBox2.Text.Trim(), phonePattern))
                return ShowError("Телефон у форматі +380 99 790 8190");

            // Адреса
            if (string.IsNullOrWhiteSpace(textBox3.Text))
                return ShowError("Введіть адресу.");

            // Послуга
            if (comboBox1.SelectedIndex <= 0)
                return ShowError("Оберіть тип послуг.");

            // Площа
            if (!double.TryParse(textBox4.Text, out double area) || area <= 0)
                return ShowError("Площа має бути більше 0.");

            // Фахівець
            if (comboBox2.SelectedIndex <= 0)
                return ShowError("Оберіть фахівця.");

            // Час прибиррання
            if (comboBox5.SelectedIndex <= 0)
                return ShowError("Оберіть час.");

            // Оплата
            if (comboBox4.SelectedIndex <= 0)
                return ShowError("Оберіть стан оплати.");

            return true;
        }

        private bool ShowError(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // --- РЕДАГУВАННЯ ---
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
            comboBox5.SelectedItem = order.TimeSlot;

            if (order.Services?.Count > 0)
            {
                comboBox1.SelectedItem = order.Services[0].CategoryService;
                comboBox3.SelectedItem = order.Services[0].OtherService;
            }

            dateTimePicker1.Value = order.OrderDate;
        }
        // Кнопка "Зберегти"
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            double area = double.Parse(textBox4.Text);

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
                    area,
                    services,
                    comboBox2.Text,
                    comboBox4.Text,
                    comboBox5.Text
                );
            }
            else
            {
                NewOrder.FullNameClient = textBox1.Text;
                NewOrder.PhoneNumber = textBox2.Text;
                NewOrder.Address = textBox3.Text;
                NewOrder.RoomArea = area;
                NewOrder.Services = services;
                NewOrder.Employee = comboBox2.Text;
                NewOrder.PaymentStatus = comboBox4.Text;
                NewOrder.OrderDate = dateTimePicker1.Value;

                NewOrder.Price = NewOrder.CalculatePrice();
            }

            //додаємо основного клієнта
            if (this.Owner is ClientMainForm mainForm)
            {
                bool added = false;

                if (this.Owner is ClientMainForm ClientMainForm)
                {
                    added = mainForm.AddOrderFromForm(NewOrder);
                }

                if (!added) return;
            }

            //питаємо чи ще нада додавати клієнта
            var result = MessageBox.Show(
                $"Ціна: {NewOrder.Price} грн\n\nДодати ще клієнта?",
                "Готово",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ClearForm(); // новий клієнт
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
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;

            dateTimePicker1.Value = DateTime.Now;
        }
    }
}