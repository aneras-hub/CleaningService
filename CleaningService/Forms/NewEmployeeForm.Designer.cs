namespace CleaningService.Forms
{
    partial class NewEmployeeForm
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
            dateTimePicker1 = new DateTimePicker();
            label14 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(204, 225);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(282, 27);
            dateTimePicker1.TabIndex = 49;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label14.Location = new Point(137, 228);
            label14.Name = "label14";
            label14.Size = new Size(59, 24);
            label14.TabIndex = 48;
            label14.Text = "Дата:";
            label14.Click += label14_Click;
            // 
            // button1
            // 
            button1.Location = new Point(178, 294);
            button1.Name = "button1";
            button1.Size = new Size(200, 35);
            button1.TabIndex = 47;
            button1.Text = "Додати фахівця";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(204, 172);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(282, 27);
            textBox2.TabIndex = 36;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(204, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 27);
            textBox1.TabIndex = 35;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(23, 172);
            label4.Name = "label4";
            label4.Size = new Size(173, 24);
            label4.TabIndex = 34;
            label4.Text = "Номер телефону:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(63, 119);
            label3.Name = "label3";
            label3.Size = new Size(133, 24);
            label3.TabIndex = 33;
            label3.Text = "ПІБ фахівця:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(204, 78);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 32;
            label2.Text = "Дані фахівця";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(156, 39);
            label1.Name = "label1";
            label1.Size = new Size(242, 27);
            label1.TabIndex = 31;
            label1.Text = "Клінінгова служба";
            // 
            // NewEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(596, 382);
            Controls.Add(dateTimePicker1);
            Controls.Add(label14);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NewEmployeeForm";
            Text = "NewEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label14;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}