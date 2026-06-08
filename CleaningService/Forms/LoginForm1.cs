namespace CleaningService
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();

            this.BackColor = Color.Honeydew;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Авторизація";

            LoginName.PlaceholderText = "Логін";
            LoginPassword.PlaceholderText = "Пароль";
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
            this.Text = "ВХІД В СИСТЕМУ";
            this.BackColor = Color.Teal;
        }

        int attempts = 0;

        private void button_Click(object sender, EventArgs e)
        {
            // Перевірка, чи не вичерпано лічильник спроб (про всяк випадок)
            if (attempts >= 3)
            {
                MessageBox.Show("Доступ заблоковано. Ви використали всі спроби.");
                return;
            }

            if (LoginName.Text == "admin" && LoginPassword.Text == "1234")
            {
                // Успішний вхід
                button.BackColor = Color.DarkSeaGreen;
                this.Text = "Вхід";

                ClientMainForm form = new ClientMainForm();
                form.Show();

                this.Hide();
            }
            else
            {
                attempts++;
                int remaining = 3 - attempts;

                if (attempts >= 3)
                {
                    MessageBox.Show("Ви 3 рази ввели невірний пароль! Кнопка входу заблокована.");
                    button.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"Невірний логін або пароль! Залишилося спроб: {remaining}");
                    LoginPassword.Clear();
                    LoginPassword.Focus();
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Honeydew;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Honeydew;
        }
    }
}