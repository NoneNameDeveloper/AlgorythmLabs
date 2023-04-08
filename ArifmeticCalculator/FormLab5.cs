using ArifmeticLibrary;
using ArrayLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            new FormMain().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 0;
            dataGridView2.ColumnCount = 0;

            int length = ArrayLibrary.Class1.InputInt(textBox1);
            double[] arr = new double[length];

            int A = ArrayLibrary.Class1.InputInt(textBox2);
            int B = ArrayLibrary.Class1.InputInt(textBox3);

            ArrayLibrary.Class1.Enter_mas(arr, length, A, B);
            ArrayLibrary.Class1.Output_mas(arr, length, dataGridView1);

            int K = ArrayLibrary.Class1.Kol(arr, length);
            MessageBox.Show($"Наименьшее положительное число, которое делится на 4: {K}");

            double[] resmas = new double[length];
            ArrayLibrary.Class1.Set_mas(arr, K, resmas, out int j);
            ArrayLibrary.Class1.Output_mas(resmas, j, dataGridView2);


        }
    }
}
