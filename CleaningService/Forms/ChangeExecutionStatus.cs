using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CleaningService.Forms
{
    public partial class ChangeExecutionStatus : Form
    {
        public Order CurrentOrder;

        public ChangeExecutionStatus(Order order)
        {
            InitializeComponent();

            BackColor = Color.Honeydew;
            StartPosition = FormStartPosition.CenterScreen;

            CurrentOrder = order;

            StanStatusu.Items.AddRange(new[]
            {
                "Заплановано",
                "Виконується",
                "Виконано",
                "Скасовано",
                "Не виконано"
            });

            StanStatusu.SelectedItem = CurrentOrder.ExecutionStatus;

            button.Text = "Зберегти";
            ApplyStyle();
        }
        private void ApplyStyle()
        {
            Font mainFont = new Font("Georgia", 12, FontStyle.Regular);
            Font buttonFont = new Font("Georgia", 12, FontStyle.Regular);

            this.Font = mainFont;

            StanStatusu.Font = mainFont;
            button.Font = buttonFont;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (StanStatusu.SelectedItem == null)
            {
                MessageBox.Show("Оберіть статус виконання!");
                return;
            }

            CurrentOrder.ExecutionStatus = StanStatusu.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
