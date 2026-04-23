namespace CleaningService
{
    partial class LoginForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm1));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            textBox1 = new TextBox();
            panel2 = new Panel();
            textBox2 = new TextBox();
            panel3 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(276, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 188);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(214, 263);
            label1.Name = "label1";
            label1.Size = new Size(308, 39);
            label1.TabIndex = 1;
            label1.Text = "ВХІД В СИСТЕМУ";
            label1.Click += label1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Honeydew;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(471, 399);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 49);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.MintCream;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(180, 317);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 42);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(188, 317);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 42);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 28);
            textBox1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSeaGreen;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(180, 399);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 49);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 9);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(273, 28);
            textBox2.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(button1);
            panel3.Location = new Point(50, 28);
            panel3.Name = "panel3";
            panel3.Size = new Size(633, 507);
            panel3.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSeaGreen;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(268, 442);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Вхід";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // LoginForm1
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(737, 570);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Font = new Font("Georgia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginForm1";
            Text = "Вхід в систему";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
        private Panel panel3;
        private Button button1;
        private TextBox textBox2;
    }
}
