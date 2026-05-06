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
            changeStatusToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            loadToolStripButton = new ToolStripButton();
            deletePolicyToolStripButton = new ToolStripButton();
            searchBox = new TextBox();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            редагуватиФахівцяToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            menuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            policiesMenuItem = new ToolStripMenuItem();
            newPolicyMenuItem = new ToolStripMenuItem();
            searchMenuItem = new ToolStripMenuItem();
            changeStatusMenuItem = new ToolStripMenuItem();
            filterMenuItem = new ToolStripMenuItem();
            filterAllMenuItem = new ToolStripMenuItem();
            filterActiveMenuItem = new ToolStripMenuItem();
            filterExpiredMenuItem = new ToolStripMenuItem();
            очікуєОплатиToolStripMenuItem = new ToolStripMenuItem();
            filterCancelledMenuItem = new ToolStripMenuItem();
            reportsMenuItem = new ToolStripMenuItem();
            statisticsMenuItem = new ToolStripMenuItem();
            incomeReportMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
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
            // 
            // changeStatusToolStripButton
            // 
            changeStatusToolStripButton.ForeColor = Color.FromArgb(26, 26, 46);
            changeStatusToolStripButton.Image = (Image)resources.GetObject("changeStatusToolStripButton.Image");
            changeStatusToolStripButton.ImageTransparentColor = Color.Magenta;
            changeStatusToolStripButton.Name = "changeStatusToolStripButton";
            changeStatusToolStripButton.Size = new Size(184, 24);
            changeStatusToolStripButton.Text = "Змінити стан оплати";
            changeStatusToolStripButton.ToolTipText = "Змінити статус полісу (Ctrl+T)";
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
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, редагуватиФахівцяToolStripMenuItem, toolStripMenuItem3 });
            toolStripMenuItem1.ForeColor = Color.FromArgb(26, 26, 46);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(212, 22);
            toolStripMenuItem1.Text = "Управління фахівцями";
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
            toolStrip.Items.AddRange(new ToolStripItem[] { newPolicyToolStripButton, deletePolicyToolStripButton, editPolicyToolStripButton, changeStatusToolStripButton, saveToolStripButton, loadToolStripButton });
            toolStrip.Location = new Point(0, 26);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(722, 27);
            toolStrip.TabIndex = 12;
            toolStrip.Text = "toolStrip1";
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Ivory;
            menuStrip.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, policiesMenuItem, toolStripMenuItem1, reportsMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(722, 26);
            menuStrip.TabIndex = 11;
            menuStrip.TabStop = true;
            menuStrip.Text = "menuStrip";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMenuItem, loadMenuItem, exitMenuItem });
            fileMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(66, 22);
            fileMenuItem.Text = "Файл";
            // 
            // saveMenuItem
            // 
            saveMenuItem.Image = (Image)resources.GetObject("saveMenuItem.Image");
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Size = new Size(291, 26);
            saveMenuItem.Text = "Зберегти";
            // 
            // loadMenuItem
            // 
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            loadMenuItem.Size = new Size(291, 26);
            loadMenuItem.Text = "Зчитати з файлу";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            exitMenuItem.Size = new Size(291, 26);
            exitMenuItem.Text = "Вихід";
            // 
            // policiesMenuItem
            // 
            policiesMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            policiesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newPolicyMenuItem, searchMenuItem, changeStatusMenuItem, filterMenuItem });
            policiesMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            policiesMenuItem.Name = "policiesMenuItem";
            policiesMenuItem.Size = new Size(244, 22);
            policiesMenuItem.Text = "Управління замовленнями";
            // 
            // newPolicyMenuItem
            // 
            newPolicyMenuItem.Name = "newPolicyMenuItem";
            newPolicyMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newPolicyMenuItem.Size = new Size(312, 26);
            newPolicyMenuItem.Text = "Нове замовлення";
            // 
            // searchMenuItem
            // 
            searchMenuItem.Name = "searchMenuItem";
            searchMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            searchMenuItem.Size = new Size(312, 26);
            searchMenuItem.Text = "Пошук замовлення";
            // 
            // changeStatusMenuItem
            // 
            changeStatusMenuItem.Name = "changeStatusMenuItem";
            changeStatusMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            changeStatusMenuItem.Size = new Size(312, 26);
            changeStatusMenuItem.Text = "Зміна замовлення";
            // 
            // filterMenuItem
            // 
            filterMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterAllMenuItem, filterActiveMenuItem, filterExpiredMenuItem, очікуєОплатиToolStripMenuItem, filterCancelledMenuItem });
            filterMenuItem.Image = (Image)resources.GetObject("filterMenuItem.Image");
            filterMenuItem.Name = "filterMenuItem";
            filterMenuItem.Size = new Size(312, 26);
            filterMenuItem.Text = "Фільтрація";
            // 
            // filterAllMenuItem
            // 
            filterAllMenuItem.Name = "filterAllMenuItem";
            filterAllMenuItem.Size = new Size(254, 26);
            filterAllMenuItem.Text = "усі";
            // 
            // filterActiveMenuItem
            // 
            filterActiveMenuItem.Name = "filterActiveMenuItem";
            filterActiveMenuItem.Size = new Size(254, 26);
            filterActiveMenuItem.Text = "Оплачено";
            // 
            // filterExpiredMenuItem
            // 
            filterExpiredMenuItem.Name = "filterExpiredMenuItem";
            filterExpiredMenuItem.Size = new Size(254, 26);
            filterExpiredMenuItem.Text = "Частково сплачено";
            // 
            // очікуєОплатиToolStripMenuItem
            // 
            очікуєОплатиToolStripMenuItem.Name = "очікуєОплатиToolStripMenuItem";
            очікуєОплатиToolStripMenuItem.Size = new Size(254, 26);
            очікуєОплатиToolStripMenuItem.Text = "Очікує оплати";
            // 
            // filterCancelledMenuItem
            // 
            filterCancelledMenuItem.Name = "filterCancelledMenuItem";
            filterCancelledMenuItem.Size = new Size(254, 26);
            filterCancelledMenuItem.Text = "Неоплачено";
            // 
            // reportsMenuItem
            // 
            reportsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statisticsMenuItem, incomeReportMenuItem });
            reportsMenuItem.ForeColor = Color.FromArgb(26, 26, 46);
            reportsMenuItem.Name = "reportsMenuItem";
            reportsMenuItem.Size = new Size(178, 22);
            reportsMenuItem.Text = "Аналіз та звітність";
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EmployeeName, EmployeeNumber, EmployeeSalary, CompletedOrders });
            dataGridView1.Location = new Point(0, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(722, 455);
            dataGridView1.TabIndex = 10;
            // 
            // EmployeeName
            // 
            EmployeeName.DataPropertyName = "EmployeeName";
            EmployeeName.HeaderText = "ПІБ";
            EmployeeName.MinimumWidth = 6;
            EmployeeName.Name = "EmployeeName";
            EmployeeName.Width = 210;
            // 
            // EmployeeNumber
            // 
            EmployeeNumber.DataPropertyName = "EmployeeNumber";
            EmployeeNumber.HeaderText = "Номер телефону";
            EmployeeNumber.MinimumWidth = 6;
            EmployeeNumber.Name = "EmployeeNumber";
            EmployeeNumber.Width = 155;
            // 
            // EmployeeSalary
            // 
            EmployeeSalary.DataPropertyName = "EmployeeSalary";
            EmployeeSalary.HeaderText = "Зарплата";
            EmployeeSalary.MinimumWidth = 6;
            EmployeeSalary.Name = "EmployeeSalary";
            EmployeeSalary.Width = 125;
            // 
            // CompletedOrders
            // 
            CompletedOrders.DataPropertyName = "CompletedOrders";
            CompletedOrders.HeaderText = "Кількість виконаних замовлень";
            CompletedOrders.MinimumWidth = 6;
            CompletedOrders.Name = "CompletedOrders";
            CompletedOrders.Width = 180;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(722, 547);
            Controls.Add(searchBox);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(dataGridView1);
            Name = "EmployeeMainForm";
            Text = "EmployeeMainForm";
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
        private ToolStripButton changeStatusToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton loadToolStripButton;
        private ToolStripButton deletePolicyToolStripButton;
        private TextBox searchBox;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem редагуватиФахівцяToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStrip toolStrip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem policiesMenuItem;
        private ToolStripMenuItem newPolicyMenuItem;
        private ToolStripMenuItem searchMenuItem;
        private ToolStripMenuItem changeStatusMenuItem;
        private ToolStripMenuItem filterMenuItem;
        private ToolStripMenuItem filterAllMenuItem;
        private ToolStripMenuItem filterActiveMenuItem;
        private ToolStripMenuItem filterExpiredMenuItem;
        private ToolStripMenuItem очікуєОплатиToolStripMenuItem;
        private ToolStripMenuItem filterCancelledMenuItem;
        private ToolStripMenuItem reportsMenuItem;
        private ToolStripMenuItem statisticsMenuItem;
        private ToolStripMenuItem incomeReportMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn EmployeeName;
        private DataGridViewTextBoxColumn EmployeeNumber;
        private DataGridViewTextBoxColumn EmployeeSalary;
        private DataGridViewTextBoxColumn CompletedOrders;
    }
}