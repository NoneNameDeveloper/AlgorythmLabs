using System.Windows.Forms;
using System;


using ArraysLibrary;

namespace ArifmeticCalculator
{
    public partial class FormLab6 : Form
    {
        public int[] algmas;
        public int length_mas;

        public FormLab6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 0;
            dataGridView2.ColumnCount = 0;

            int length = Class1.InputInt(textBox1);
            int[] arr = new int[length];

            int A = Class1.InputInt(textBox2);
            int B = Class1.InputInt(textBox3);

            Class1.Enter_mas(arr, length, A, B);
            Class1.Output_mas(arr, length, dataGridView1);

            int K = Class1.Kol(arr, length);

            int[] resmas = new int[length];
            Class1.Set_mas(arr, K, resmas, out int j);
            Class1.Output_mas(resmas, j, dataGridView2);
            algmas = resmas;
            length_mas = j;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.AlgTask4(algmas, algmas.Length);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.AlgTask8(algmas, algmas.Length);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.AlgTask10(algmas, length_mas);
            Class1.Output_mas(algmas, algmas.Length, dataGridView3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.AlgTask11(algmas, length_mas);
            Class1.Output_mas(algmas, algmas.Length, dataGridView4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1.AlgTask12(algmas, length_mas);
            Class1.Output_mas(algmas, length_mas, dataGridView5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormMain().ShowDialog();
        }
    }
}
