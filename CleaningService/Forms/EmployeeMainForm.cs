using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleaningService.Forms
{
    public partial class EmployeeMainForm : Form
    {
        public EmployeeMainForm()
        {
            InitializeComponent();

            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;

            searchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            //щоб текст в колонках автоматично підлаштовувався
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // посередині текст
            dataGridView1.Columns["EmployeeNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["EmployeeSalary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["CompletedOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void OrderAdministrationMenuItem_Click(object sender, EventArgs e)
        {
            ClientMainForm form = new ClientMainForm();
            this.Hide();
            form.ShowDialog();
        }

        private void reportsMenuItem_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics();
            this.Hide();
            form.ShowDialog();
        }

        private void OrderEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMainForm form = new EmployeeMainForm();
            this.Hide();
            form.ShowDialog();
        }
    }
}
