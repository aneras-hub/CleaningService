namespace CleaningService
{
    partial class NewClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewClientForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            NameClient = new TextBox();
            NumberClient = new TextBox();
            label5 = new Label();
            AreaRoom = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            AdressClient = new TextBox();
            label10 = new Label();
            label12 = new Label();
            label13 = new Label();
            button = new Button();
            label14 = new Label();
            dateTimePicker = new DateTimePicker();
            Posluga = new ComboBox();
            label9 = new Label();
            PlusPosluga = new ComboBox();
            StanOplatu = new ComboBox();
            EmployeeClean = new ComboBox();
            TimeCleaning = new ComboBox();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(143, 18);
            label1.Name = "label1";
            label1.Size = new Size(242, 27);
            label1.TabIndex = 0;
            label1.Text = "Клінінгова служба";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(236, 64);
            label2.Name = "label2";
            label2.Size = new Size(149, 27);
            label2.TabIndex = 1;
            label2.Text = "Дані клієнта";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(101, 121);
            label3.Name = "label3";
            label3.Size = new Size(128, 24);
            label3.TabIndex = 2;
            label3.Text = "ПІБ клієнта:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(149, 174);
            label4.Name = "label4";
            label4.Size = new Size(78, 24);
            label4.TabIndex = 3;
            label4.Text = "Номер:";
            // 
            // NameClient
            // 
            NameClient.Location = new Point(235, 116);
            NameClient.Name = "NameClient";
            NameClient.Size = new Size(282, 34);
            NameClient.TabIndex = 4;
            // 
            // NumberClient
            // 
            NumberClient.Location = new Point(235, 169);
            NumberClient.Name = "NumberClient";
            NumberClient.Size = new Size(282, 34);
            NumberClient.TabIndex = 5;
            NumberClient.KeyPress += NumberClient_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.DarkGreen;
            label5.Location = new Point(203, 280);
            label5.Name = "label5";
            label5.Size = new Size(217, 27);
            label5.TabIndex = 6;
            label5.Text = "Деталі замовлення";
            // 
            // AreaRoom
            // 
            AreaRoom.Location = new Point(236, 391);
            AreaRoom.Name = "AreaRoom";
            AreaRoom.Size = new Size(282, 34);
            AreaRoom.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(150, 396);
            label6.Name = "label6";
            label6.Size = new Size(82, 24);
            label6.TabIndex = 8;
            label6.Text = "Площа:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(112, 343);
            label7.Name = "label7";
            label7.Size = new Size(120, 24);
            label7.TabIndex = 7;
            label7.Text = "Тип послуг:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(43, 504);
            label8.Name = "label8";
            label8.Size = new Size(189, 24);
            label8.TabIndex = 12;
            label8.Text = "Додаткові послуги:";
            // 
            // AdressClient
            // 
            AdressClient.Location = new Point(235, 230);
            AdressClient.Name = "AdressClient";
            AdressClient.Size = new Size(282, 34);
            AdressClient.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.Location = new Point(149, 235);
            label10.Name = "label10";
            label10.Size = new Size(80, 24);
            label10.TabIndex = 15;
            label10.Text = "Адреса:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(99, 667);
            label12.Name = "label12";
            label12.Size = new Size(131, 24);
            label12.TabIndex = 17;
            label12.Text = "Стан оплати:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label13.Location = new Point(60, 616);
            label13.Name = "label13";
            label13.Size = new Size(169, 24);
            label13.TabIndex = 21;
            label13.Text = "Час прибирання:";
            // 
            // button
            // 
            button.Location = new Point(204, 725);
            button.Name = "button";
            button.Size = new Size(200, 35);
            button.TabIndex = 22;
            button.Text = "Додати клієнта";
            button.UseVisualStyleBackColor = true;
            button.Click += button1_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label14.Location = new Point(173, 556);
            label14.Name = "label14";
            label14.Size = new Size(59, 24);
            label14.TabIndex = 23;
            label14.Text = "Дата:";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(236, 556);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(282, 34);
            dateTimePicker.TabIndex = 24;
            // 
            // Posluga
            // 
            Posluga.DropDownStyle = ComboBoxStyle.DropDownList;
            Posluga.FormattingEnabled = true;
            Posluga.Location = new Point(236, 338);
            Posluga.Name = "Posluga";
            Posluga.Size = new Size(282, 35);
            Posluga.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(131, 451);
            label9.Name = "label9";
            label9.Size = new Size(100, 24);
            label9.TabIndex = 11;
            label9.Text = "Фахівець:";
            // 
            // PlusPosluga
            // 
            PlusPosluga.DropDownStyle = ComboBoxStyle.DropDownList;
            PlusPosluga.FormattingEnabled = true;
            PlusPosluga.Location = new Point(236, 499);
            PlusPosluga.Name = "PlusPosluga";
            PlusPosluga.Size = new Size(282, 35);
            PlusPosluga.TabIndex = 26;
            // 
            // StanOplatu
            // 
            StanOplatu.DropDownStyle = ComboBoxStyle.DropDownList;
            StanOplatu.FormattingEnabled = true;
            StanOplatu.Location = new Point(236, 662);
            StanOplatu.Name = "StanOplatu";
            StanOplatu.Size = new Size(282, 35);
            StanOplatu.TabIndex = 27;
            // 
            // EmployeeClean
            // 
            EmployeeClean.DropDownStyle = ComboBoxStyle.DropDownList;
            EmployeeClean.FormattingEnabled = true;
            EmployeeClean.Location = new Point(236, 445);
            EmployeeClean.Name = "EmployeeClean";
            EmployeeClean.Size = new Size(282, 35);
            EmployeeClean.TabIndex = 28;
            // 
            // TimeCleaning
            // 
            TimeCleaning.DropDownStyle = ComboBoxStyle.DropDownList;
            TimeCleaning.FormattingEnabled = true;
            TimeCleaning.Location = new Point(236, 611);
            TimeCleaning.Name = "TimeCleaning";
            TimeCleaning.Size = new Size(282, 35);
            TimeCleaning.TabIndex = 29;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(491, 230);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(10, 34);
            textBox5.TabIndex = 30;
            // 
            // NewClientForm
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(630, 800);
            Controls.Add(TimeCleaning);
            Controls.Add(EmployeeClean);
            Controls.Add(StanOplatu);
            Controls.Add(PlusPosluga);
            Controls.Add(Posluga);
            Controls.Add(dateTimePicker);
            Controls.Add(label14);
            Controls.Add(button);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(AdressClient);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(AreaRoom);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(NumberClient);
            Controls.Add(NameClient);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Font = new Font("Georgia", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewClientForm";
            Text = "Клієнт";
            KeyPress += NewClientForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox NameClient;
        private TextBox NumberClient;
        private Label label5;
        private TextBox AreaRoom;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox AdressClient;
        private Label label10;
        private Label label12;
        private Label label13;
        private Button button;
        private Label label14;
        private DateTimePicker dateTimePicker;
        private ComboBox Posluga;
        private Label label9;
        private ComboBox PlusPosluga;
        private ComboBox StanOplatu;
        private ComboBox EmployeeClean;
        private ComboBox TimeCleaning;
        private TextBox textBox5;
    }
}