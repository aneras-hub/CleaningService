namespace CleaningService.Forms
{
    partial class EmployeeMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMainForm));
            SearchBox = new TextBox();
            dataGridView = new DataGridView();
            BirthDate = new DataGridViewTextBoxColumn();
            EmployeeName = new DataGridViewTextBoxColumn();
            EmployeeNumber = new DataGridViewTextBoxColumn();
            EmployeeSalary = new DataGridViewTextBoxColumn();
            CompletedOrders = new DataGridViewTextBoxColumn();
            OrderEmployeeMenuItem = new ToolStripMenuItem();
            NewEmployeeMenuItem = new ToolStripMenuItem();
            EditEmployeeMenuItem = new ToolStripMenuItem();
            DeleteEmployeeMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            FileMenuItem = new ToolStripMenuItem();
            SaveMenuItem = new ToolStripMenuItem();
            LoadMenuItem = new ToolStripMenuItem();
            ExitMenuItem = new ToolStripMenuItem();
            OrderAdministrationMenuItem = new ToolStripMenuItem();
            StatisticsMenuItem = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            NewEmployeeToolStripButton = new ToolStripButton();
            DeleteEmployeeToolStripButton = new ToolStripButton();
            EditEmployeeToolStripButton = new ToolStripButton();
            SaveToolStripButton = new ToolStripButton();
            LoadToolStripButton = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // SearchBox
            // 
            SearchBox.BackColor = Color.Ivory;
            SearchBox.BorderStyle = BorderStyle.FixedSingle;
            SearchBox.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            SearchBox.ForeColor = Color.DarkOliveGreen;
            SearchBox.Location = new Point(12, 56);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            SearchBox.Size = new Size(324, 28);
            SearchBox.TabIndex = 13;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.BackgroundColor = Color.SeaShell;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { BirthDate, EmployeeName, EmployeeNumber, EmployeeSalary, CompletedOrders });
            dataGridView.Location = new Point(0, 90);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(929, 321);
            dataGridView.TabIndex = 10;
            // 
            // BirthDate
            // 
            BirthDate.HeaderText = "Дата народження";
            BirthDate.MinimumWidth = 6;
            BirthDate.Name = "BirthDate";
            BirthDate.Width = 125;
            // 
            // EmployeeName
            // 
            EmployeeName.DataPropertyName = "EmployeeName";
            EmployeeName.HeaderText = "ПІБ";
            EmployeeName.MinimumWidth = 6;
            EmployeeName.Name = "EmployeeName";
            EmployeeName.Width = 230;
            // 
            // EmployeeNumber
            // 
            EmployeeNumber.DataPropertyName = "EmployeeNumber";
            EmployeeNumber.HeaderText = "Номер телефону";
            EmployeeNumber.MinimumWidth = 6;
            EmployeeNumber.Name = "EmployeeNumber";
            EmployeeNumber.Width = 160;
            // 
            // EmployeeSalary
            // 
            EmployeeSalary.DataPropertyName = "EmployeeSalary";
            EmployeeSalary.HeaderText = "Зарплата";
            EmployeeSalary.MinimumWidth = 6;
            EmployeeSalary.Name = "EmployeeSalary";
            EmployeeSalary.Width = 140;
            // 
            // CompletedOrders
            // 
            CompletedOrders.DataPropertyName = "CompletedOrders";
            CompletedOrders.HeaderText = "Кількість виконаних замовлень";
            CompletedOrders.MinimumWidth = 6;
            CompletedOrders.Name = "CompletedOrders";
            CompletedOrders.Width = 220;
            // 
            // OrderEmployeeMenuItem
            // 
            OrderEmployeeMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OrderEmployeeMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewEmployeeMenuItem, EditEmployeeMenuItem, DeleteEmployeeMenuItem });
            OrderEmployeeMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            OrderEmployeeMenuItem.Name = "OrderEmployeeMenuItem";
            OrderEmployeeMenuItem.Size = new Size(212, 24);
            OrderEmployeeMenuItem.Text = "Управління фахівцями";
            // 
            // NewEmployeeMenuItem
            // 
            NewEmployeeMenuItem.Name = "NewEmployeeMenuItem";
            NewEmployeeMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            NewEmployeeMenuItem.Size = new Size(301, 26);
            NewEmployeeMenuItem.Text = "Новий фахівець";
            NewEmployeeMenuItem.Click += NewEmployeeMenuItem_Click;
            // 
            // EditEmployeeMenuItem
            // 
            EditEmployeeMenuItem.Name = "EditEmployeeMenuItem";
            EditEmployeeMenuItem.Size = new Size(301, 26);
            EditEmployeeMenuItem.Text = "Редагувати фахівця";
            EditEmployeeMenuItem.Click += EditEmployeeMenuItem_Click;
            // 
            // DeleteEmployeeMenuItem
            // 
            DeleteEmployeeMenuItem.CheckOnClick = true;
            DeleteEmployeeMenuItem.Name = "DeleteEmployeeMenuItem";
            DeleteEmployeeMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            DeleteEmployeeMenuItem.Size = new Size(301, 26);
            DeleteEmployeeMenuItem.Text = "Видалити фахівця";
            DeleteEmployeeMenuItem.Click += DeleteEmployeeMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Ivory;
            menuStrip.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { FileMenuItem, OrderAdministrationMenuItem, OrderEmployeeMenuItem, StatisticsMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(928, 28);
            menuStrip.TabIndex = 11;
            menuStrip.TabStop = true;
            menuStrip.Text = "menuStrip";
            // 
            // FileMenuItem
            // 
            FileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveMenuItem, LoadMenuItem, ExitMenuItem });
            FileMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            FileMenuItem.Name = "FileMenuItem";
            FileMenuItem.Size = new Size(66, 24);
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
            ExitMenuItem.Click += ExitMenuItem_Click;
            // 
            // OrderAdministrationMenuItem
            // 
            OrderAdministrationMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OrderAdministrationMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            OrderAdministrationMenuItem.Name = "OrderAdministrationMenuItem";
            OrderAdministrationMenuItem.Size = new Size(244, 24);
            OrderAdministrationMenuItem.Text = "Управління замовленнями";
            OrderAdministrationMenuItem.Click += OrderAdministrationMenuItem_Click_1;
            // 
            // StatisticsMenuItem
            // 
            StatisticsMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            StatisticsMenuItem.Name = "StatisticsMenuItem";
            StatisticsMenuItem.Size = new Size(114, 24);
            StatisticsMenuItem.Text = "Статистика";
            StatisticsMenuItem.Click += StatisticsMenuItem_Click;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.Ivory;
            toolStrip.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { NewEmployeeToolStripButton, DeleteEmployeeToolStripButton, EditEmployeeToolStripButton, SaveToolStripButton, LoadToolStripButton });
            toolStrip.Location = new Point(0, 28);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(928, 27);
            toolStrip.TabIndex = 12;
            toolStrip.Text = "toolStrip1";
            // 
            // NewEmployeeToolStripButton
            // 
            NewEmployeeToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            NewEmployeeToolStripButton.Image = (Image)resources.GetObject("NewEmployeeToolStripButton.Image");
            NewEmployeeToolStripButton.ImageTransparentColor = Color.Magenta;
            NewEmployeeToolStripButton.Name = "NewEmployeeToolStripButton";
            NewEmployeeToolStripButton.Size = new Size(87, 24);
            NewEmployeeToolStripButton.Text = "Додати";
            NewEmployeeToolStripButton.ToolTipText = "Додати нового фахівця";
            NewEmployeeToolStripButton.Click += NewEmployeeToolStripButton_Click;
            // 
            // DeleteEmployeeToolStripButton
            // 
            DeleteEmployeeToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            DeleteEmployeeToolStripButton.Image = (Image)resources.GetObject("DeleteEmployeeToolStripButton.Image");
            DeleteEmployeeToolStripButton.ImageTransparentColor = Color.Magenta;
            DeleteEmployeeToolStripButton.Name = "DeleteEmployeeToolStripButton";
            DeleteEmployeeToolStripButton.Size = new Size(103, 24);
            DeleteEmployeeToolStripButton.Text = "Видалити";
            DeleteEmployeeToolStripButton.ToolTipText = "Видалити вибраного фахівця";
            DeleteEmployeeToolStripButton.Click += DeleteEmployeeToolStripButton_Click;
            // 
            // EditEmployeeToolStripButton
            // 
            EditEmployeeToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            EditEmployeeToolStripButton.Image = (Image)resources.GetObject("EditEmployeeToolStripButton.Image");
            EditEmployeeToolStripButton.ImageTransparentColor = Color.Magenta;
            EditEmployeeToolStripButton.Name = "EditEmployeeToolStripButton";
            EditEmployeeToolStripButton.Size = new Size(118, 24);
            EditEmployeeToolStripButton.Text = "Редагувати";
            EditEmployeeToolStripButton.ToolTipText = "Редагувати вибраного фахівця";
            EditEmployeeToolStripButton.Click += EditEmployeeToolStripButton_Click;
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
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(928, 411);
            Controls.Add(SearchBox);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(dataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeMainForm";
            Text = "Таблиця фахівців";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox SearchBox;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn BirthDate;
        private DataGridViewTextBoxColumn EmployeeName;
        private DataGridViewTextBoxColumn EmployeeNumber;
        private DataGridViewTextBoxColumn EmployeeSalary;
        private DataGridViewTextBoxColumn CompletedOrders;
        private ToolStripMenuItem OrderEmployeeMenuItem;
        private ToolStripMenuItem NewEmployeeMenuItem;
        private ToolStripMenuItem EditEmployeeMenuItem;
        private ToolStripMenuItem DeleteEmployeeMenuItem;
        private MenuStrip menuStrip;
        private ToolStrip toolStrip;
        private ToolStripMenuItem FileMenuItem;
        private ToolStripMenuItem SaveMenuItem;
        private ToolStripMenuItem LoadMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem OrderAdministrationMenuItem;
        private ToolStripMenuItem StatisticsMenuItem;
        private ToolStripButton NewEmployeeToolStripButton;
        private ToolStripButton DeleteEmployeeToolStripButton;
        private ToolStripButton EditEmployeeToolStripButton;
        private ToolStripButton SaveToolStripButton;
        private ToolStripButton LoadToolStripButton;
    }
}