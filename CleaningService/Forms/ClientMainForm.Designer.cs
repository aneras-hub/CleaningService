namespace CleaningService
{
    partial class ClientMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainForm));
            menuStrip = new MenuStrip();
            FileMenuItem = new ToolStripMenuItem();
            SaveMenuItem = new ToolStripMenuItem();
            LoadMenuItem = new ToolStripMenuItem();
            ExitMenuItem = new ToolStripMenuItem();
            OrderAdministrationMenuItem = new ToolStripMenuItem();
            NewOrderMenuItem = new ToolStripMenuItem();
            EditOrdertoolStrip = new ToolStripMenuItem();
            DeletetoolStrip = new ToolStripMenuItem();
            FiltertoolStrip = new ToolStripMenuItem();
            fAllMenuItem = new ToolStripMenuItem();
            fOplachenoMenuItem = new ToolStripMenuItem();
            fHalfOplatchenoMenuItem = new ToolStripMenuItem();
            fWaitOplataMenuItem = new ToolStripMenuItem();
            fAnyOplataMenuItem = new ToolStripMenuItem();
            ClearAllMenuItem = new ToolStripMenuItem();
            OrderEmployeeMenuItem = new ToolStripMenuItem();
            StatisticsMenuItem = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            NewOrderToolStripButton = new ToolStripButton();
            DeleteOrderToolStripButton = new ToolStripButton();
            EditOrderToolStripButton = new ToolStripButton();
            ChangeOplataToolStripButton = new ToolStripButton();
            SaveToolStripButton = new ToolStripButton();
            LoadToolStripButton = new ToolStripButton();
            dataGridView1 = new DataGridView();
            Column7 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            SearchBox = new TextBox();
            ChangeExecutionStatustoolStripButton = new ToolStripButton();
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Ivory;
            menuStrip.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { FileMenuItem, OrderAdministrationMenuItem, OrderEmployeeMenuItem, StatisticsMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1462, 26);
            menuStrip.TabIndex = 2;
            menuStrip.TabStop = true;
            menuStrip.Text = "menuStrip";
            // 
            // FileMenuItem
            // 
            FileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveMenuItem, LoadMenuItem, ExitMenuItem });
            FileMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            FileMenuItem.Name = "FileMenuItem";
            FileMenuItem.Size = new Size(66, 22);
            FileMenuItem.Text = "Файл";
            // 
            // SaveMenuItem
            // 
            SaveMenuItem.Image = (Image)resources.GetObject("SaveMenuItem.Image");
            SaveMenuItem.Name = "SaveMenuItem";
            SaveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveMenuItem.Size = new Size(291, 26);
            SaveMenuItem.Text = "Зберегти";
            SaveMenuItem.Click += SaveMenuItem_Click;
            // 
            // LoadMenuItem
            // 
            LoadMenuItem.Name = "LoadMenuItem";
            LoadMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            LoadMenuItem.Size = new Size(291, 26);
            LoadMenuItem.Text = "Зчитати з файлу";
            LoadMenuItem.Click += LoadMenuItem_Click;
            // 
            // ExitMenuItem
            // 
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            ExitMenuItem.Size = new Size(291, 26);
            ExitMenuItem.Text = "Вихід";
            ExitMenuItem.Click += exitMenuItem_Click;
            // 
            // OrderAdministrationMenuItem
            // 
            OrderAdministrationMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OrderAdministrationMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewOrderMenuItem, EditOrdertoolStrip, DeletetoolStrip, FiltertoolStrip, ClearAllMenuItem });
            OrderAdministrationMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            OrderAdministrationMenuItem.Name = "OrderAdministrationMenuItem";
            OrderAdministrationMenuItem.Size = new Size(244, 22);
            OrderAdministrationMenuItem.Text = "Управління замовленнями";
            // 
            // NewOrderMenuItem
            // 
            NewOrderMenuItem.Name = "NewOrderMenuItem";
            NewOrderMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            NewOrderMenuItem.Size = new Size(364, 26);
            NewOrderMenuItem.Text = "Нове замовлення";
            NewOrderMenuItem.Click += NewOrderMenuItem_Click;
            // 
            // EditOrdertoolStrip
            // 
            EditOrdertoolStrip.Name = "EditOrdertoolStrip";
            EditOrdertoolStrip.ShortcutKeys = Keys.Control | Keys.T;
            EditOrdertoolStrip.Size = new Size(364, 26);
            EditOrdertoolStrip.Text = "Редагування замовлення";
            EditOrdertoolStrip.Click += EditOrdertoolStrip_Click;
            // 
            // DeletetoolStrip
            // 
            DeletetoolStrip.Name = "DeletetoolStrip";
            DeletetoolStrip.ShortcutKeys = Keys.Control | Keys.F;
            DeletetoolStrip.Size = new Size(364, 26);
            DeletetoolStrip.Text = "Видалення замовлення";
            DeletetoolStrip.Click += DeletetoolStrip_Click;
            // 
            // FiltertoolStrip
            // 
            FiltertoolStrip.DropDownItems.AddRange(new ToolStripItem[] { fAllMenuItem, fOplachenoMenuItem, fHalfOplatchenoMenuItem, fWaitOplataMenuItem, fAnyOplataMenuItem });
            FiltertoolStrip.Image = (Image)resources.GetObject("FiltertoolStrip.Image");
            FiltertoolStrip.Name = "FiltertoolStrip";
            FiltertoolStrip.Size = new Size(364, 26);
            FiltertoolStrip.Text = "Фільтрація";
            // 
            // fAllMenuItem
            // 
            fAllMenuItem.Name = "fAllMenuItem";
            fAllMenuItem.Size = new Size(254, 26);
            fAllMenuItem.Text = "усі";
            // 
            // fOplachenoMenuItem
            // 
            fOplachenoMenuItem.Name = "fOplachenoMenuItem";
            fOplachenoMenuItem.Size = new Size(254, 26);
            fOplachenoMenuItem.Text = "Оплачено";
            // 
            // fHalfOplatchenoMenuItem
            // 
            fHalfOplatchenoMenuItem.Name = "fHalfOplatchenoMenuItem";
            fHalfOplatchenoMenuItem.Size = new Size(254, 26);
            fHalfOplatchenoMenuItem.Text = "Частково сплачено";
            // 
            // fWaitOplataMenuItem
            // 
            fWaitOplataMenuItem.Name = "fWaitOplataMenuItem";
            fWaitOplataMenuItem.Size = new Size(254, 26);
            fWaitOplataMenuItem.Text = "Очікує оплати";
            // 
            // fAnyOplataMenuItem
            // 
            fAnyOplataMenuItem.Name = "fAnyOplataMenuItem";
            fAnyOplataMenuItem.Size = new Size(254, 26);
            fAnyOplataMenuItem.Text = "Неоплачено";
            // 
            // ClearAllMenuItem
            // 
            ClearAllMenuItem.Name = "ClearAllMenuItem";
            ClearAllMenuItem.Size = new Size(364, 26);
            ClearAllMenuItem.Text = "Очистити таблицю";
            ClearAllMenuItem.Click += ClearAllMenuItem_Click;
            // 
            // OrderEmployeeMenuItem
            // 
            OrderEmployeeMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OrderEmployeeMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            OrderEmployeeMenuItem.Name = "OrderEmployeeMenuItem";
            OrderEmployeeMenuItem.Size = new Size(212, 22);
            OrderEmployeeMenuItem.Text = "Управління фахівцями";
            OrderEmployeeMenuItem.Click += OrderEmployeeMenuItem_Click;
            // 
            // StatisticsMenuItem
            // 
            StatisticsMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            StatisticsMenuItem.Name = "StatisticsMenuItem";
            StatisticsMenuItem.Size = new Size(114, 22);
            StatisticsMenuItem.Text = "Статистика";
            StatisticsMenuItem.Click += StatisticsMenuItem_Click;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.Ivory;
            toolStrip.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { NewOrderToolStripButton, DeleteOrderToolStripButton, EditOrderToolStripButton, ChangeOplataToolStripButton, ChangeExecutionStatustoolStripButton, SaveToolStripButton, LoadToolStripButton });
            toolStrip.Location = new Point(0, 26);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1462, 27);
            toolStrip.TabIndex = 7;
            toolStrip.Text = "toolStrip1";
            // 
            // NewOrderToolStripButton
            // 
            NewOrderToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            NewOrderToolStripButton.Image = (Image)resources.GetObject("NewOrderToolStripButton.Image");
            NewOrderToolStripButton.ImageTransparentColor = Color.Magenta;
            NewOrderToolStripButton.Name = "NewOrderToolStripButton";
            NewOrderToolStripButton.Size = new Size(87, 24);
            NewOrderToolStripButton.Text = "Додати";
            NewOrderToolStripButton.ToolTipText = "Додати нове замовлення";
            NewOrderToolStripButton.Click += NewOrderToolStripButton_Click;
            // 
            // DeleteOrderToolStripButton
            // 
            DeleteOrderToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            DeleteOrderToolStripButton.Image = (Image)resources.GetObject("DeleteOrderToolStripButton.Image");
            DeleteOrderToolStripButton.ImageTransparentColor = Color.Magenta;
            DeleteOrderToolStripButton.Name = "DeleteOrderToolStripButton";
            DeleteOrderToolStripButton.Size = new Size(103, 24);
            DeleteOrderToolStripButton.Text = "Видалити";
            DeleteOrderToolStripButton.ToolTipText = "Видалити вибране замовлення";
            DeleteOrderToolStripButton.Click += DeleteOrderToolStripButton_Click;
            // 
            // EditOrderToolStripButton
            // 
            EditOrderToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            EditOrderToolStripButton.Image = (Image)resources.GetObject("EditOrderToolStripButton.Image");
            EditOrderToolStripButton.ImageTransparentColor = Color.Magenta;
            EditOrderToolStripButton.Name = "EditOrderToolStripButton";
            EditOrderToolStripButton.Size = new Size(118, 24);
            EditOrderToolStripButton.Text = "Редагувати";
            EditOrderToolStripButton.ToolTipText = "Редагувати вибране замовлення";
            EditOrderToolStripButton.Click += EditOrderToolStripButton_Click;
            // 
            // ChangeOplataToolStripButton
            // 
            ChangeOplataToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            ChangeOplataToolStripButton.Image = (Image)resources.GetObject("ChangeOplataToolStripButton.Image");
            ChangeOplataToolStripButton.ImageTransparentColor = Color.Magenta;
            ChangeOplataToolStripButton.Name = "ChangeOplataToolStripButton";
            ChangeOplataToolStripButton.Size = new Size(184, 24);
            ChangeOplataToolStripButton.Text = "Змінити стан оплати";
            ChangeOplataToolStripButton.ToolTipText = "Змінити стан оплати";
            ChangeOplataToolStripButton.Click += ChangeOplataToolStripButton_Click;
            // 
            // SaveToolStripButton
            // 
            SaveToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            SaveToolStripButton.Image = (Image)resources.GetObject("SaveToolStripButton.Image");
            SaveToolStripButton.ImageTransparentColor = Color.Magenta;
            SaveToolStripButton.Name = "SaveToolStripButton";
            SaveToolStripButton.Size = new Size(100, 24);
            SaveToolStripButton.Text = "Зберегти";
            SaveToolStripButton.ToolTipText = "Зберегти дані";
            SaveToolStripButton.Click += SaveToolStripButton_Click;
            // 
            // LoadToolStripButton
            // 
            LoadToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            LoadToolStripButton.Image = (Image)resources.GetObject("LoadToolStripButton.Image");
            LoadToolStripButton.ImageTransparentColor = Color.Magenta;
            LoadToolStripButton.Name = "LoadToolStripButton";
            LoadToolStripButton.Size = new Size(91, 24);
            LoadToolStripButton.Text = "Зчитати";
            LoadToolStripButton.ToolTipText = "Зчитати дані";
            LoadToolStripButton.Click += LoadToolStripButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.SeaShell;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column7, Column1, Column2, Column9, Column8, Column3, Column4, Column5, Column6, Column10 });
            dataGridView1.Location = new Point(0, 97);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1462, 443);
            dataGridView1.TabIndex = 1;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "OrderDate";
            Column7.HeaderText = "Дата";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 85;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "FullNameClient";
            Column1.HeaderText = "ПІБ";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 210;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "Address";
            Column2.HeaderText = "Адреса";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 200;
            // 
            // Column9
            // 
            Column9.DataPropertyName = "PhoneNumber";
            Column9.HeaderText = "Номер";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.Width = 145;
            // 
            // Column8
            // 
            Column8.HeaderText = "Відповідальний фахівець";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "RoomArea";
            Column3.HeaderText = "Площа приміщення";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Тип послуги";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "Price";
            Column5.HeaderText = "Вартість послуги";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "PaymentStatus";
            Column6.HeaderText = "Стан оплати";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 120;
            // 
            // Column10
            // 
            Column10.HeaderText = "Статус виконання";
            Column10.DataPropertyName = "ExecutionStatus";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.Width = 130;
            // 
            // SearchBox
            // 
            SearchBox.BackColor = Color.Ivory;
            SearchBox.BorderStyle = BorderStyle.FixedSingle;
            SearchBox.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            SearchBox.ForeColor = Color.DarkOliveGreen;
            SearchBox.Location = new Point(12, 61);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            SearchBox.Size = new Size(324, 28);
            SearchBox.TabIndex = 9;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // ChangeExecutionStatustoolStripButton
            // 
            ChangeExecutionStatustoolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            ChangeExecutionStatustoolStripButton.Image = (Image)resources.GetObject("ChangeExecutionStatustoolStripButton.Image");
            ChangeExecutionStatustoolStripButton.ImageTransparentColor = Color.Magenta;
            ChangeExecutionStatustoolStripButton.Name = "ChangeExecutionStatustoolStripButton";
            ChangeExecutionStatustoolStripButton.Size = new Size(213, 24);
            ChangeExecutionStatustoolStripButton.Text = "Змінити стан виконання";
            ChangeExecutionStatustoolStripButton.ToolTipText = "Змінити стан оплати";
            ChangeExecutionStatustoolStripButton.Click += ChangeExecutionStatustoolStripButton_Click;
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1462, 536);
            Controls.Add(SearchBox);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientMainForm";
            Text = "Таблиця клієнтів";
            FormClosing += ClientMainForm_FormClosing;
            FormClosed += ClientMainForm_FormClosed;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem FileMenuItem;
        private ToolStripMenuItem SaveMenuItem;
        private ToolStripMenuItem LoadMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStrip toolStrip;
        private ToolStripButton NewOrderToolStripButton;
        private ToolStripButton DeleteOrderToolStripButton;
        private ToolStripButton EditOrderToolStripButton;
        private ToolStripButton ChangeOplataToolStripButton;
        private ToolStripButton SaveToolStripButton;
        private ToolStripButton LoadToolStripButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private TextBox SearchBox;
        private ToolStripMenuItem OrderAdministrationMenuItem;
        private ToolStripMenuItem NewOrderMenuItem;
        private ToolStripMenuItem DeletetoolStrip;
        private ToolStripMenuItem EditOrdertoolStrip;
        private ToolStripMenuItem FiltertoolStrip;
        private ToolStripMenuItem fAllMenuItem;
        private ToolStripMenuItem fOplachenoMenuItem;
        private ToolStripMenuItem fHalfOplatchenoMenuItem;
        private ToolStripMenuItem fWaitOplataMenuItem;
        private ToolStripMenuItem fAnyOplataMenuItem;
        private ToolStripMenuItem OrderEmployeeMenuItem;
        private ToolStripMenuItem StatisticsMenuItem;
        private ToolStripMenuItem ClearAllMenuItem;
        private DataGridViewTextBoxColumn Column10;
        private ToolStripButton ChangeExecutionStatustoolStripButton;
    }
}