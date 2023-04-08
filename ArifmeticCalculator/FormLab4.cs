using ArifmeticLibrary;


namespace ArifmeticCalculator
{
    public partial class FormLab4 : Form
    {
        public FormLab4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormLab1().Show();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = Class1.Input(textBox1);
            double Eps = Class1.Input(textBox2);

            Class1.ProcessExpressionLab4(x0, Eps, 100, dataGridView1);
        }

    }
}
