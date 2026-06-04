namespace CleaningService
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();

            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Àâòîðèçàö³ÿ";

            LoginName.PlaceholderText = "Ëîã³í";
            LoginPassword.PlaceholderText = "Ïàðîëü";
            this.ActiveControl = button;

            ApplyStyle();
        }

        private void ApplyStyle()
        {
            Font mainFont = new Font("Georgia", 12, FontStyle.Regular);
            Font titleFont = new Font("Georgia", 20, FontStyle.Regular);
            Font buttonFont = new Font("Georgia", 12, FontStyle.Regular);

            this.Font = mainFont;

            ApplyFontToControls(this, mainFont);

            label.Font = titleFont;
            button.Font = buttonFont;

            LoginName.Font = mainFont;
            LoginPassword.Font = mainFont;
        }

        private void ApplyFontToControls(Control parent, Font font)
        {
            foreach (Control control in parent.Controls)
            {
                control.Font = font;

                if (control.HasChildren)
                    ApplyFontToControls(control, font);
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            this.Text = "ÂÕ²Ä Â ÑÈÑÒÅÌÓ";
            this.BackColor = Color.Teal;
        }

        int attempts = 0;

        private void button_Click(object sender, EventArgs e)
        {
            ClientMainForm form = new ClientMainForm();
            form.Show();

            this.Hide();
        }
        private void pictureBox_Click_1(object sender, EventArgs e)
        {
            pictureBox.Location = new Point((this.ClientSize.Width - pictureBox.Width) / 2, 20);
            pictureBox.Anchor = AnchorStyles.Top;
        }
    }
}