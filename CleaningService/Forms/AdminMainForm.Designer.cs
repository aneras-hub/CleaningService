namespace CleaningService
{
    partial class AdminMainForm
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
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(21, 50);
            label1.Name = "label1";
            label1.Size = new Size(516, 39);
            label1.TabIndex = 2;
            label1.Text = "АДМІНІСТРАТИВНА ПАНЕЛЬ";
            // 
            // button1
            // 
            button1.Location = new Point(130, 170);
            button1.Name = "button1";
            button1.Size = new Size(292, 35);
            button1.TabIndex = 3;
            button1.Text = "Таблиця клієнтів";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(130, 262);
            button3.Name = "button3";
            button3.Size = new Size(292, 35);
            button3.TabIndex = 5;
            button3.Text = "Статистика";
            button3.UseVisualStyleBackColor = true;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(549, 406);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "AdminMainForm";
            Text = "AdminMainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button3;
    }
}