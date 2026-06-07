using System;
using System.Drawing;
using System.Reflection.Emit;
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

            StanOplatu.Items.AddRange(new[]
            {
                "Частково сплачено",
                "Оплачено",
                "Очікує оплати",
                "Неоплачено"
            });

            // ставимо поточний стан
            StanOplatu.SelectedItem = CurrentOrder.PaymentStatus;

            button.Text = "Зберегти";
            button.Click += button1_Click;
            ApplyStyle();
        }
        private void ApplyStyle()
        {
            Font mainFont = new Font("Georgia", 12, FontStyle.Regular);
            Font buttonFont = new Font("Georgia", 12, FontStyle.Regular);

            this.Font = mainFont;

            StanOplatu.Font = mainFont;
            button.Font = buttonFont;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (StanOplatu.SelectedItem == null)
            {
                MessageBox.Show("Оберіть стан оплати!");
                return;
            }

            // змінює стан
            CurrentOrder.PaymentStatus = StanOplatu.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void StanOplatu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}