using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleaningService
{
    public partial class FlashForm : Form
    {
        private System.Windows.Forms.Timer fadeTimer;
        private int waitCounter = 0;

        public FlashForm()
        {
            InitializeComponent();

            this.Opacity = 0;
            this.StartPosition = FormStartPosition.CenterScreen;

            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 40;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            else
            {
                waitCounter++;

                if (waitCounter >= 15)
                {
                    fadeTimer.Stop();
                    this.Close();
                }
            }
        }
    }
}