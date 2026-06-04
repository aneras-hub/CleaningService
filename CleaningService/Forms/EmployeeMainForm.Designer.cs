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
            OrderEmployeeMenuItem = new ToolStripMenuItem();
            NewEmployeeMenuItem = new ToolStripMenuItem();
            EditEmployeeMenuItem = new ToolStripMenuItem();
            DeleteEmployeeMenuItem = new ToolStripMenuItem();
            AllStatisticMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            NewClientToolStripButton = new ToolStripButton();
            DeleteClientToolStripButton = new ToolStripButton();
            EditClientToolStripButton = new ToolStripButton();
            SaveFileToolStripButton = new ToolStripButton();
            LoadFileToolStripButton = new ToolStripButton();
            toolStrip = new ToolStrip();
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
            SearchBox.TextChanged += searchBox_TextChanged_1;
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
            // 
            // EditEmployeeMenuItem
            // 
            EditEmployeeMenuItem.Name = "EditEmployeeMenuItem";
            EditEmployeeMenuItem.Size = new Size(301, 26);
            EditEmployeeMenuItem.Text = "Редагувати фахівця";
            // 
            // DeleteEmployeeMenuItem
            // 
            DeleteEmployeeMenuItem.Name = "DeleteEmployeeMenuItem";
            DeleteEmployeeMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            DeleteEmployeeMenuItem.Size = new Size(301, 26);
            DeleteEmployeeMenuItem.Text = "Видалити фахівця";
            // 
            // AllStatisticMenuItem
            // 
            AllStatisticMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            AllStatisticMenuItem.Name = "AllStatisticMenuItem";
            AllStatisticMenuItem.Size = new Size(178, 24);
            AllStatisticMenuItem.Text = "Аналіз та звітність";
            AllStatisticMenuItem.Click += reportsMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Ivory;
            menuStrip.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { FileMenuItem, OrderAdministrationMenuItem, OrderEmployeeMenuItem, AllStatisticMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(928, 28);
            menuStrip.TabIndex = 11;
            menuStrip.TabStop = true;
            menuStrip.Text = "menuStrip";
            // 
            // NewClientToolStripButton
            // 
            NewClientToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            NewClientToolStripButton.Image = (Image)resources.GetObject("NewClientToolStripButton.Image");
            NewClientToolStripButton.ImageTransparentColor = Color.Magenta;
            NewClientToolStripButton.Name = "NewClientToolStripButton";
            NewClientToolStripButton.Size = new Size(87, 24);
            NewClientToolStripButton.Text = "Додати";
            NewClientToolStripButton.ToolTipText = "Додати новий поліс (Ctrl+N)";
            NewClientToolStripButton.Click += newPolicyToolStripButton_Click;
            // 
            // DeleteClientToolStripButton
            // 
            DeleteClientToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            DeleteClientToolStripButton.Image = (Image)resources.GetObject("DeleteClientToolStripButton.Image");
            DeleteClientToolStripButton.ImageTransparentColor = Color.Magenta;
            DeleteClientToolStripButton.Name = "DeleteClientToolStripButton";
            DeleteClientToolStripButton.Size = new Size(103, 24);
            DeleteClientToolStripButton.Text = "Видалити";
            DeleteClientToolStripButton.ToolTipText = "Видалити вибраний поліс";
            DeleteClientToolStripButton.Click += deletePolicyToolStripButton_Click;
            // 
            // EditClientToolStripButton
            // 
            EditClientToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            EditClientToolStripButton.Image = (Image)resources.GetObject("EditClientToolStripButton.Image");
            EditClientToolStripButton.ImageTransparentColor = Color.Magenta;
            EditClientToolStripButton.Name = "EditClientToolStripButton";
            EditClientToolStripButton.Size = new Size(118, 24);
            EditClientToolStripButton.Text = "Редагувати";
            EditClientToolStripButton.ToolTipText = "Редагувати вибраний поліс";
            EditClientToolStripButton.Click += editPolicyToolStripButton_Click;
            // 
            // SaveFileToolStripButton
            // 
            SaveFileToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            SaveFileToolStripButton.Image = (Image)resources.GetObject("SaveFileToolStripButton.Image");
            SaveFileToolStripButton.ImageTransparentColor = Color.Magenta;
            SaveFileToolStripButton.Name = "SaveFileToolStripButton";
            SaveFileToolStripButton.Size = new Size(100, 24);
            SaveFileToolStripButton.Text = "Зберегти";
            SaveFileToolStripButton.ToolTipText = "Зберегти дані (Ctrl+S)";
            // 
            // LoadFileToolStripButton
            // 
            LoadFileToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            LoadFileToolStripButton.Image = (Image)resources.GetObject("LoadFileToolStripButton.Image");
            LoadFileToolStripButton.ImageTransparentColor = Color.Magenta;
            LoadFileToolStripButton.Name = "LoadFileToolStripButton";
            LoadFileToolStripButton.Size = new Size(91, 24);
            LoadFileToolStripButton.Text = "Зчитати";
            LoadFileToolStripButton.ToolTipText = "Зчитати дані (Ctrl+O)";
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.Ivory;
            toolStrip.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { NewClientToolStripButton, DeleteClientToolStripButton, EditClientToolStripButton, SaveFileToolStripButton, LoadFileToolStripButton });
            toolStrip.Location = new Point(0, 28);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(928, 27);
            toolStrip.TabIndex = 12;
            toolStrip.Text = "toolStrip1";
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
            Load += EmployeeMainForm_Load;
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
        private ToolStripMenuItem OrderEmployeeMenuItem;
        private ToolStripMenuItem NewEmployeeMenuItem;
        private ToolStripMenuItem EditEmployeeMenuItem;
        private ToolStripMenuItem DeleteEmployeeMenuItem;
        private ToolStripMenuItem AllStatisticMenuItem;
        private MenuStrip menuStrip;
        private ToolStripButton NewClientToolStripButton;
        private ToolStripButton DeleteClientToolStripButton;
        private ToolStripButton EditClientToolStripButton;
        private ToolStripButton SaveFileToolStripButton;
        private ToolStripButton LoadFileToolStripButton;
        private ToolStrip toolStrip;
    }
}