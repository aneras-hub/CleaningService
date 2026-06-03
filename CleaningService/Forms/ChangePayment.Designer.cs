namespace CleaningService
{
    partial class ChangePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePayment));
            StanOplatu = new ComboBox();
            label12 = new Label();
            button = new Button();
            SuspendLayout();
            // 
            // StanOplatu
            // 
            StanOplatu.DropDownStyle = ComboBoxStyle.DropDownList;
            StanOplatu.FormattingEnabled = true;
            StanOplatu.Location = new Point(165, 36);
            StanOplatu.Name = "StanOplatu";
            StanOplatu.Size = new Size(282, 28);
            StanOplatu.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(28, 41);
            label12.Name = "label12";
            label12.Size = new Size(131, 24);
            label12.TabIndex = 28;
            label12.Text = "Стан оплати:";
            // 
            // button
            // 
            button.Location = new Point(165, 99);
            button.Name = "button";
            button.Size = new Size(146, 37);
            button.TabIndex = 30;
            button.Text = "button";
            button.UseVisualStyleBackColor = true;
            // 
            // ChangePayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(480, 160);
            Controls.Add(button);
            Controls.Add(StanOplatu);
            Controls.Add(label12);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangePayment";
            Text = "Зміна оплати";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox StanOplatu;
        private Label label12;
        private Button button;
    }
}