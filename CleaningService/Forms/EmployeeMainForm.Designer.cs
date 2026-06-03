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
            newPolicyToolStripButton = new ToolStripButton();
            editPolicyToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            loadToolStripButton = new ToolStripButton();
            deletePolicyToolStripButton = new ToolStripButton();
            searchBox = new TextBox();
            OrderEmployeeMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            редагуватиФахівцяToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            menuStrip = new MenuStrip();
            FileMenuItem = new ToolStripMenuItem();
            SaveMenuItem = new ToolStripMenuItem();
            LoadMenuItem = new ToolStripMenuItem();
            ExitMenuItem = new ToolStripMenuItem();
            OrderAdministrationMenuItem = new ToolStripMenuItem();
            NewOrderMenuItem = new ToolStripMenuItem();
            SearchMenuItem = new ToolStripMenuItem();
            ChangeStatusMenuItem = new ToolStripMenuItem();
            FilterMenuItem = new ToolStripMenuItem();
            fAllMenuItem = new ToolStripMenuItem();
            fOplachenoMenuItem = new ToolStripMenuItem();
            fHalfOplatchenoMenuItem = new ToolStripMenuItem();
            fWaitOplataMenuItem = new ToolStripMenuItem();
            fAnyOplataMenuItem = new ToolStripMenuItem();
            reportsMenuItem = new ToolStripMenuItem();
            statisticsMenuItem = new ToolStripMenuItem();
            incomeReportMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            BirthDate = new DataGridViewTextBoxColumn();
            EmployeeName = new DataGridViewTextBoxColumn();
            EmployeeNumber = new DataGridViewTextBoxColumn();
            EmployeeSalary = new DataGridViewTextBoxColumn();
            CompletedOrders = new DataGridViewTextBoxColumn();
            toolStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // newPolicyToolStripButton
            // 
            newPolicyToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            newPolicyToolStripButton.Image = (Image)resources.GetObject("newPolicyToolStripButton.Image");
            newPolicyToolStripButton.ImageTransparentColor = Color.Magenta;
            newPolicyToolStripButton.Name = "newPolicyToolStripButton";
            newPolicyToolStripButton.Size = new Size(87, 24);
            newPolicyToolStripButton.Text = "Додати";
            newPolicyToolStripButton.ToolTipText = "Додати новий поліс (Ctrl+N)";
            newPolicyToolStripButton.Click += newPolicyToolStripButton_Click;
            // 
            // editPolicyToolStripButton
            // 
            editPolicyToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            editPolicyToolStripButton.Image = (Image)resources.GetObject("editPolicyToolStripButton.Image");
            editPolicyToolStripButton.ImageTransparentColor = Color.Magenta;
            editPolicyToolStripButton.Name = "editPolicyToolStripButton";
            editPolicyToolStripButton.Size = new Size(118, 24);
            editPolicyToolStripButton.Text = "Редагувати";
            editPolicyToolStripButton.ToolTipText = "Редагувати вибраний поліс";
            editPolicyToolStripButton.Click += editPolicyToolStripButton_Click;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(100, 24);
            saveToolStripButton.Text = "Зберегти";
            saveToolStripButton.ToolTipText = "Зберегти дані (Ctrl+S)";
            // 
            // loadToolStripButton
            // 
            loadToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            loadToolStripButton.Image = (Image)resources.GetObject("loadToolStripButton.Image");
            loadToolStripButton.ImageTransparentColor = Color.Magenta;
            loadToolStripButton.Name = "loadToolStripButton";
            loadToolStripButton.Size = new Size(91, 24);
            loadToolStripButton.Text = "Зчитати";
            loadToolStripButton.ToolTipText = "Зчитати дані (Ctrl+O)";
            // 
            // deletePolicyToolStripButton
            // 
            deletePolicyToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            deletePolicyToolStripButton.Image = (Image)resources.GetObject("deletePolicyToolStripButton.Image");
            deletePolicyToolStripButton.ImageTransparentColor = Color.Magenta;
            deletePolicyToolStripButton.Name = "deletePolicyToolStripButton";
            deletePolicyToolStripButton.Size = new Size(103, 24);
            deletePolicyToolStripButton.Text = "Видалити";
            deletePolicyToolStripButton.ToolTipText = "Видалити вибраний поліс";
            deletePolicyToolStripButton.Click += deletePolicyToolStripButton_Click;
            // 
            // searchBox
            // 
            searchBox.BackColor = Color.Ivory;
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            searchBox.ForeColor = Color.DarkOliveGreen;
            searchBox.Location = new Point(12, 56);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            searchBox.Size = new Size(324, 28);
            searchBox.TabIndex = 13;
            searchBox.TextChanged += searchBox_TextChanged_1;
            // 
            // OrderEmployeeMenuItem
            // 
            OrderEmployeeMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OrderEmployeeMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, редагуватиФахівцяToolStripMenuItem, toolStripMenuItem3 });
            OrderEmployeeMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            OrderEmployeeMenuItem.Name = "OrderEmployeeMenuItem";
            OrderEmployeeMenuItem.Size = new Size(212, 24);
            OrderEmployeeMenuItem.Text = "Управління фахівцями";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.ShortcutKeys = Keys.Control | Keys.N;
            toolStripMenuItem2.Size = new Size(301, 26);
            toolStripMenuItem2.Text = "Новий фахівець";
            // 
            // редагуватиФахівцяToolStripMenuItem
            // 
            редагуватиФахівцяToolStripMenuItem.Name = "редагуватиФахівцяToolStripMenuItem";
            редагуватиФахівцяToolStripMenuItem.Size = new Size(301, 26);
            редагуватиФахівцяToolStripMenuItem.Text = "Редагувати фахівця";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.ShortcutKeys = Keys.Control | Keys.F;
            toolStripMenuItem3.Size = new Size(301, 26);
            toolStripMenuItem3.Text = "Видалити фахівця";
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.Ivory;
            toolStrip.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { newPolicyToolStripButton, deletePolicyToolStripButton, editPolicyToolStripButton, saveToolStripButton, loadToolStripButton });
            toolStrip.Location = new Point(0, 28);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(928, 27);
            toolStrip.TabIndex = 12;
            toolStrip.Text = "toolStrip1";
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Ivory;
            menuStrip.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { FileMenuItem, OrderAdministrationMenuItem, OrderEmployeeMenuItem, reportsMenuItem });
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
            // 
            // LoadMenuItem
            // 
            LoadMenuItem.Name = "LoadMenuItem";
            LoadMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            LoadMenuItem.Size = new Size(291, 26);
            LoadMenuItem.Text = "Зчитати з файлу";
            // 
            // ExitMenuItem
            // 
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            ExitMenuItem.Size = new Size(291, 26);
            ExitMenuItem.Text = "Вихід";
            // 
            // OrderAdministrationMenuItem
            // 
            OrderAdministrationMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OrderAdministrationMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewOrderMenuItem, SearchMenuItem, ChangeStatusMenuItem, FilterMenuItem });
            OrderAdministrationMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            OrderAdministrationMenuItem.Name = "OrderAdministrationMenuItem";
            OrderAdministrationMenuItem.Size = new Size(244, 24);
            OrderAdministrationMenuItem.Text = "Управління замовленнями";
            OrderAdministrationMenuItem.Click += OrderAdministrationMenuItem_Click;
            // 
            // NewOrderMenuItem
            // 
            NewOrderMenuItem.Name = "NewOrderMenuItem";
            NewOrderMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            NewOrderMenuItem.Size = new Size(312, 26);
            NewOrderMenuItem.Text = "Нове замовлення";
            // 
            // SearchMenuItem
            // 
            SearchMenuItem.Name = "SearchMenuItem";
            SearchMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            SearchMenuItem.Size = new Size(312, 26);
            SearchMenuItem.Text = "Пошук замовлення";
            // 
            // ChangeStatusMenuItem
            // 
            ChangeStatusMenuItem.Name = "ChangeStatusMenuItem";
            ChangeStatusMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            ChangeStatusMenuItem.Size = new Size(312, 26);
            ChangeStatusMenuItem.Text = "Зміна замовлення";
            // 
            // FilterMenuItem
            // 
            FilterMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fAllMenuItem, fOplachenoMenuItem, fHalfOplatchenoMenuItem, fWaitOplataMenuItem, fAnyOplataMenuItem });
            FilterMenuItem.Image = (Image)resources.GetObject("FilterMenuItem.Image");
            FilterMenuItem.Name = "FilterMenuItem";
            FilterMenuItem.Size = new Size(312, 26);
            FilterMenuItem.Text = "Фільтрація";
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
            // reportsMenuItem
            // 
            reportsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statisticsMenuItem, incomeReportMenuItem });
            reportsMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            reportsMenuItem.Name = "reportsMenuItem";
            reportsMenuItem.Size = new Size(178, 24);
            reportsMenuItem.Text = "Аналіз та звітність";
            reportsMenuItem.Click += reportsMenuItem_Click;
            // 
            // statisticsMenuItem
            // 
            statisticsMenuItem.Name = "statisticsMenuItem";
            statisticsMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            statisticsMenuItem.Size = new Size(386, 26);
            statisticsMenuItem.Text = "Статистика по замовленням";
            // 
            // incomeReportMenuItem
            // 
            incomeReportMenuItem.Name = "incomeReportMenuItem";
            incomeReportMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            incomeReportMenuItem.Size = new Size(386, 26);
            incomeReportMenuItem.Text = "Звіт по доходах";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.SeaShell;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BirthDate, EmployeeName, EmployeeNumber, EmployeeSalary, CompletedOrders });
            dataGridView1.Location = new Point(0, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(929, 321);
            dataGridView1.TabIndex = 10;
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
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(928, 411);
            Controls.Add(searchBox);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeMainForm";
            Text = "Таблиця фахівців";
            Load += EmployeeMainForm_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripButton newPolicyToolStripButton;
        private ToolStripButton editPolicyToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton loadToolStripButton;
        private ToolStripButton deletePolicyToolStripButton;
        private TextBox searchBox;
        private ToolStripMenuItem OrderEmployeeMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem редагуватиФахівцяToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStrip toolStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem FileMenuItem;
        private ToolStripMenuItem SaveMenuItem;
        private ToolStripMenuItem LoadMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem OrderAdministrationMenuItem;
        private ToolStripMenuItem NewOrderMenuItem;
        private ToolStripMenuItem SearchMenuItem;
        private ToolStripMenuItem ChangeStatusMenuItem;
        private ToolStripMenuItem FilterMenuItem;
        private ToolStripMenuItem fAllMenuItem;
        private ToolStripMenuItem fOplachenoMenuItem;
        private ToolStripMenuItem fHalfOplatchenoMenuItem;
        private ToolStripMenuItem fWaitOplataMenuItem;
        private ToolStripMenuItem fAnyOplataMenuItem;
        private ToolStripMenuItem reportsMenuItem;
        private ToolStripMenuItem statisticsMenuItem;
        private ToolStripMenuItem incomeReportMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn BirthDate;
        private DataGridViewTextBoxColumn EmployeeName;
        private DataGridViewTextBoxColumn EmployeeNumber;
        private DataGridViewTextBoxColumn EmployeeSalary;
        private DataGridViewTextBoxColumn CompletedOrders;
    }
}