namespace CleaningService.Forms
{
    partial class ChangeExecutionStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeExecutionStatus));
            button = new Button();
            StanStatusu = new ComboBox();
            label12 = new Label();
            SuspendLayout();
            // 
            // button
            // 
            button.Location = new Point(222, 121);
            button.Name = "button";
            button.Size = new Size(146, 37);
            button.TabIndex = 33;
            button.Text = "button";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // StanStatusu
            // 
            StanStatusu.DropDownStyle = ComboBoxStyle.DropDownList;
            StanStatusu.FormattingEnabled = true;
            StanStatusu.Location = new Point(300, 60);
            StanStatusu.Name = "StanStatusu";
            StanStatusu.Size = new Size(282, 28);
            StanStatusu.TabIndex = 32;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(12, 60);
            label12.Name = "label12";
            label12.Size = new Size(282, 24);
            label12.TabIndex = 31;
            label12.Text = "Стан виконання замовлення:";
            // 
            // ChangeExecutionStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(596, 187);
            Controls.Add(button);
            Controls.Add(StanStatusu);
            Controls.Add(label12);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangeExecutionStatus";
            Text = "Зміна виконання замовлень";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button;
        private ComboBox StanStatusu;
        private Label label12;
    }
}