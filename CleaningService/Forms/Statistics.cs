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
    public partial class Statistics: Form
    {
        public Statistics()
        {
            InitializeComponent();
            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;


        }
    }
}
