using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CleaningService.Forms
{
    public partial class NewEmployeeForm : Form
    {
        public NewEmployeeForm()
        {
            InitializeComponent();
            dateTimePicker.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker.MinDate = DateTime.Today.AddYears(-100);
            ApplyStyle();
        }
        private void label14_Click(object sender, EventArgs e)
        {        }
        public Employee NewEmployee { get; set; }
        public NewEmployeeForm(Employee employee) : this()
        {
            this.NewEmployee = employee;
            FullNameBox.Text = employee.EmployeeName;
            NumberBox.Text = employee.EmployeeNumber;
            button.Text = "Зберегти зміни";
        }
        private void ApplyStyle()
        {
            label1.Font = new Font("Georgia", 14, FontStyle.Regular); // Клінінгова служба
            label2.Font = new Font("Georgia", 11, FontStyle.Regular); // Дані фахівця

            label3.Font = new Font("Georgia", 10, FontStyle.Regular);
            label4.Font = new Font("Georgia", 10, FontStyle.Regular);
            label14.Font = new Font("Georgia", 10, FontStyle.Regular);

            FullNameBox.Font = new Font("Georgia", 10);
            NumberBox.Font = new Font("Georgia", 10);
            dateTimePicker.Font = new Font("Georgia", 10);

            button.Font = new Font("Georgia", 10, FontStyle.Bold);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = FullNameBox.Text.Trim();
            string phone = NumberBox.Text.Trim();
            DateTime birthDate = dateTimePicker.Value.Date;

            string[] parts = fullName.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                MessageBox.Show(
                    "ПІБ повинно містити прізвище, ім’я та по батькові.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            foreach (string part in parts)
            {
                if (part.Length < 2)
                {
                    MessageBox.Show(
                        "Кожна частина ПІБ повинна містити мінімум 2 символи.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                foreach (char c in part)
                {
                    if (!char.IsLetter(c) && c != '\'' && c != '’' && c != '-')
                    {
                        MessageBox.Show(
                            "ПІБ може містити лише літери, дефіс та апостроф.",
                            "Помилка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            string phoneDigits = phone
                .Replace(" ", "")
                .Replace("-", "");

            if (!phoneDigits.StartsWith("+380") ||
                phoneDigits.Length != 13 ||
                !phoneDigits.Substring(1).All(char.IsDigit))
            {
                MessageBox.Show(
                    "Номер телефону повинен бути у форматі +380991234567.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age < 18)
            {
                MessageBox.Show(
                    "Працівнику повинно бути не менше 18 років.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (age > 100)
            {
                MessageBox.Show(
                    "Вік працівника не може перевищувати 100 років.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (NewEmployee == null)
            {
                NewEmployee = new Employee();
            }

            NewEmployee.EmployeeName = fullName;
            NewEmployee.EmployeeNumber = phone;
            NewEmployee.BirthDate = birthDate;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
