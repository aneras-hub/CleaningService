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
            this.Font = new Font("Georgia", 11, FontStyle.Regular);
            this.AutoScaleMode = AutoScaleMode;
            textBox1.PlaceholderText = "Логін";
            textBox2.PlaceholderText = "Пароль";
            this.ActiveControl = button1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, 20);
            pictureBox1.Anchor = AnchorStyles.Top;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Text = "ВХІД В СИСТЕМУ";
            this.BackColor = Color.Teal;
        }

        // Додай цей рядок вище, там де оголошені змінні класу (над button1_Click)
        int attempts = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірка, чи не вичерпано лічильник спроб (про всяк випадок)
            if (attempts >= 3)
            {
                MessageBox.Show("Доступ заблоковано. Ви використали всі спроби.");
                return;
            }

            if (textBox1.Text == "admin" || textBox1.Text == "фвьшт" && textBox2.Text == "1234")
            {
                // Успішний вхід
                button1.BackColor = Color.DarkSeaGreen;
                this.Text = "Вхід";

                AdminMainForm form = new AdminMainForm();
                form.Show();

                this.Hide(); // Ховаємо вікно тільки якщо дані вірні
            }
            else
            {
                // Помилка
                attempts++; // Збільшуємо кількість спроб
                int remaining = 3 - attempts;

                if (attempts >= 3)
                {
                    MessageBox.Show("Ви 3 рази ввели невірний пароль! Кнопка входу заблокована.");
                    button1.Enabled = false; // Блокуємо кнопку
                                             // Або можна закрити програму: Application.Exit();
                }
                else
                {
                    MessageBox.Show($"Невірний логін або пароль! Залишилося спроб: {remaining}");

                    // Очищаємо поля для нового введення (опціонально)
                    textBox2.Clear();
                    textBox2.Focus();
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