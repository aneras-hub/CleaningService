using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CleaningService.Forms
{
    // якщо замовлення 10 , то оплата має бути вже 9

    public partial class Statistics : Form
    {
        private OrderEmployee employeeManager;
        public Statistics(OrderEmployee manager)
        {
            InitializeComponent();
            this.employeeManager = manager;
            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {

        }

        private void searchMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void OrderEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMainForm form = new EmployeeMainForm(employeeManager);
            this.Hide();
            form.ShowDialog();
        }

        private void OrderAdministrationMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }
    }
}
