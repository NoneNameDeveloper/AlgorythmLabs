using System;
using System.Windows.Forms;

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

            new FormLab1().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab2().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab3().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab4().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab5().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab6().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab8().ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab7().ShowDialog();
        }
    }
}