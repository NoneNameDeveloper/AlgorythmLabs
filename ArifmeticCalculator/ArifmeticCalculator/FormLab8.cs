using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOX;
using ArifmeticLibrary;
using DoubleArrayLibrary;
using Microsoft.Office.Interop.Word;

namespace ArifmeticCalculator
{
    public partial class FormLab8 : Form
    {
        public static int[,] algmas;
        public static int[] resmas;
        public static int n; // строки (rows)
        public static int m; // столбцы (columns)

        public static int resmas_length;

        public static int raznost_;

        public FormLab8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int A = DoubleArrayClass.InputInt(textBox1);
            int B = DoubleArrayClass.InputInt(textBox2);

            int[,] arr = new int[A, B];

            DoubleArrayClass.ArrayGenerate(arr, A, B);

            algmas = arr;
            n = A;
            m = B;

            DoubleArrayClass.Output_mas(arr, A, B, dataGridView1);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int raznost = DoubleArrayClass.MaxMinRaznost(algmas, n, m);
            MessageBox.Show($"Разность максимального и минимального элементов матрицы: {raznost.ToString()}", "Информация");

            raznost_ = raznost;
            int[] resmas_ = new int[n * m];

            DoubleArrayClass.GenerateArr(algmas, n, m, raznost, resmas_, out int g);
            resmas_length = g;
            DoubleArrayClass.Output_mas1(resmas_, g, dataGridView2);
            resmas = resmas_;
        }

        // Notepad
        private void button2_Click(object sender, EventArgs e)
        {
            DoubleArrayClass.Write_To_Note(algmas, resmas, n, m, resmas_length);
            MessageBox.Show("Запись произведена. Вы можете открыть текстовый файл.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Access
        private void button4_Click(object sender, EventArgs e)
        {
            DoubleArrayClass.Create_DB();
            DoubleArrayClass.CreateStructDB(m);
            DoubleArrayClass.AddToDB(algmas, n, m);
        }

        // Excel
        private void button5_Click(object sender, EventArgs e)
        {
            DoubleArrayClass.Write_To_Excel(algmas, resmas, n, m, resmas_length);
        }

        // Word
        private void button6_Click(object sender, EventArgs e)
        {
            DoubleArrayClass.Write_To_Word(algmas, resmas, n, m, resmas_length, raznost_);
        }
    }
}
