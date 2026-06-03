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
            pictureBox = new PictureBox();
            label = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            LoginName = new TextBox();
            panel2 = new Panel();
            LoginPassword = new TextBox();
            panel3 = new Panel();
            button = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(276, 49);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(176, 188);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Georgia", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label.ForeColor = Color.Teal;
            label.Location = new Point(214, 263);
            label.Name = "label";
            label.Size = new Size(308, 39);
            label.TabIndex = 1;
            label.Text = "ВХІД В СИСТЕМУ";
            label.Click += label1_Click;
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
            panel1.Controls.Add(LoginName);
            panel1.Location = new Point(188, 317);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 42);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // LoginName
            // 
            LoginName.Location = new Point(43, 6);
            LoginName.Name = "LoginName";
            LoginName.Size = new Size(282, 28);
            LoginName.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSeaGreen;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(LoginPassword);
            panel2.Location = new Point(180, 399);
            panel2.Name = "panel2";
            panel2.Size = new Size(342, 49);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // LoginPassword
            // 
            LoginPassword.Location = new Point(7, 9);
            LoginPassword.Name = "LoginPassword";
            LoginPassword.Size = new Size(273, 28);
            LoginPassword.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(button);
            panel3.Location = new Point(50, 28);
            panel3.Name = "panel3";
            panel3.Size = new Size(633, 507);
            panel3.TabIndex = 7;
            // 
            // button
            // 
            button.BackColor = Color.DarkSeaGreen;
            button.ForeColor = SystemColors.ControlText;
            button.Location = new Point(268, 442);
            button.Name = "button";
            button.Size = new Size(94, 29);
            button.TabIndex = 0;
            button.Text = "Вхід";
            button.UseVisualStyleBackColor = false;
            button.Click += button1_Click;
            // 
            // LoginForm1
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(737, 570);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(label);
            Controls.Add(pictureBox);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Font = new Font("Georgia", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginForm1";
            Text = "Вхід в систему";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
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

        private PictureBox pictureBox;
        private Label label;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private TextBox LoginName;
        private Panel panel3;
        private Button button;
        private TextBox LoginPassword;
    }
}
