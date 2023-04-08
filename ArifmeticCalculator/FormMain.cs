namespace ArifmeticCalculator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab1().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab2().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab3().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab4().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab5().Show();
        }
    }
}