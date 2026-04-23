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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkSeaGreen;
            this.Text = "Вхід";
            AdminMainForm adminMainForm = new AdminMainForm();
            adminMainForm.Show();
            this.Hide();
            if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                AdminMainForm form = new AdminMainForm();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль");
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