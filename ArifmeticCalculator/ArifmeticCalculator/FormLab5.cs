using System;
using System.Windows.Forms;

namespace ArifmeticCalculator
{
    public partial class FormLab5 : Form
    {
        public FormLab5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormMain().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 0;
            dataGridView2.ColumnCount = 0;

            int length = ArraysLibrary.Class1.InputInt(textBox1);
            int[] arr = new int[length];

            int A = ArraysLibrary.Class1.InputInt(textBox2);
            int B = ArraysLibrary.Class1.InputInt(textBox3);

            ArraysLibrary.Class1.Enter_mas(arr, length, A, B);
            ArraysLibrary.Class1.Output_mas(arr, length, dataGridView1);

            int K = ArraysLibrary.Class1.Kol(arr, length);
            MessageBox.Show($"Наименьшее положительное число, которое делится на 4: {K}");

            int[] resmas = new int[length];
            ArraysLibrary.Class1.Set_mas(arr, K, resmas, out int j);
            ArraysLibrary.Class1.Output_mas(resmas, j, dataGridView2);


        }
    }
}
