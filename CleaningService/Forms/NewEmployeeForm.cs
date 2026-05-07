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
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        // Додайте це поле в клас
        public Employee NewEmployee { get; set; }

        // Додайте цей конструктор
        public NewEmployeeForm(Employee employee) : this()
        {
            this.NewEmployee = employee;

            // Заповнюємо текстові поля даними для редагування
            // Перевірте назви ваших TextBox на дизайні (на скриншоті це ПІБ та Номер)
            textBox1.Text = employee.EmployeeName;
            textBox2.Text = employee.EmployeeNumber;

            // Змінюємо текст кнопки, щоб користувач розумів, що це редагування
            button1.Text = "Зберегти зміни";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NewEmployee == null)
            {
                NewEmployee = new Employee();
            }

            //Оновлюємо дані з текстових полів
            NewEmployee.EmployeeName = textBox1.Text.Trim();
            NewEmployee.EmployeeNumber = textBox2.Text.Trim();
            NewEmployee.BirthDate = dateTimePicker1.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
