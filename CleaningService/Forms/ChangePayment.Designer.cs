namespace CleaningService
{
    partial class ChangePayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox4 = new ComboBox();
            label12 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(165, 36);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(282, 28);
            comboBox4.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(28, 41);
            label12.Name = "label12";
            label12.Size = new Size(131, 24);
            label12.TabIndex = 28;
            label12.Text = "Стан оплати:";
            // 
            // button1
            // 
            button1.Location = new Point(188, 99);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 30;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // ChangePayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(480, 160);
            Controls.Add(button1);
            Controls.Add(comboBox4);
            Controls.Add(label12);
            Name = "ChangePayment";
            Text = "ChangePayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox4;
        private Label label12;
        private Button button1;
    }
}