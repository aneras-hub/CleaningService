using System;
using System.Drawing;
using System.Windows.Forms;

namespace CleaningService
{
    public partial class ChangePayment : Form
    {
        public Order CurrentOrder;

        public ChangePayment(Order order)
        {
            InitializeComponent();

            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;

            CurrentOrder = order;

            comboBox4.Items.AddRange(new[]
            {
                "Частково сплачено",
                "Оплачено",
                "Очікує оплати",
                "Неоплачено"
            });

            // ставимо поточний стан
            comboBox4.SelectedItem = CurrentOrder.PaymentStatus;

            button1.Text = "Зберегти";
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Оберіть стан оплати!");
                return;
            }

            // змінює стан
            CurrentOrder.PaymentStatus = comboBox4.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}