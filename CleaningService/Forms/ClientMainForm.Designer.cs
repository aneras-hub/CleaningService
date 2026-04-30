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
            toolStrip = new ToolStrip();
            newPolicyToolStripButton = new ToolStripButton();
            deletePolicyToolStripButton = new ToolStripButton();
            editPolicyToolStripButton = new ToolStripButton();
            changeStatusToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            loadToolStripButton = new ToolStripButton();
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
            searchBox = new TextBox();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenuItem, policiesMenuItem, reportsMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1412, 26);
            menuStrip.TabIndex = 2;
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
            // toolStrip
            // 
            toolStrip.BackColor = Color.Ivory;
            toolStrip.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { newPolicyToolStripButton, deletePolicyToolStripButton, editPolicyToolStripButton, changeStatusToolStripButton, saveToolStripButton, loadToolStripButton });
            toolStrip.Location = new Point(0, 26);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1412, 27);
            toolStrip.TabIndex = 7;
            toolStrip.Text = "toolStrip1";
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
            newPolicyToolStripButton.Click += newPolicyToolStripButton_Click_1;
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
            changeStatusToolStripButton.Click += changeStatusToolStripButton_Click;
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.SeaShell;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column7, Column1, Column2, Column9, Column8, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(0, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1416, 455);
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
            // searchBox
            // 
            searchBox.BackColor = Color.Ivory;
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            searchBox.ForeColor = Color.DarkOliveGreen;
            searchBox.Location = new Point(12, 59);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Пошук по ПІБ, номеру, стану оплати";
            searchBox.Size = new Size(324, 28);
            searchBox.TabIndex = 9;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1412, 536);
            Controls.Add(searchBox);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(dataGridView1);
            Name = "ClientMainForm";
            Text = "MainForm";
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
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem policiesMenuItem;
        private ToolStripMenuItem newPolicyMenuItem;
        private ToolStripMenuItem переглядВсіхToolStripMenuItem;
        private ToolStripMenuItem searchMenuItem;
        private ToolStripMenuItem changeStatusMenuItem;
        private ToolStripMenuItem filterMenuItem;
        private ToolStripMenuItem filterAllMenuItem;
        private ToolStripMenuItem filterActiveMenuItem;
        private ToolStripMenuItem filterExpiredMenuItem;
        private ToolStripMenuItem filterCancelledMenuItem;
        private ToolStripMenuItem reportsMenuItem;
        private ToolStripMenuItem statisticsMenuItem;
        private ToolStripMenuItem incomeReportMenuItem;
        private ToolStrip toolStrip;
        private ToolStripButton newPolicyToolStripButton;
        private ToolStripButton deletePolicyToolStripButton;
        private ToolStripButton editPolicyToolStripButton;
        private ToolStripButton changeStatusToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton loadToolStripButton;
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
        private ToolStripMenuItem очікуєОплатиToolStripMenuItem;
        private TextBox searchBox;
    }
}