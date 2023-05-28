using System;
using System.Windows.Forms;



using ArraysLibrary;


namespace ArifmeticCalculator
{
    public partial class FormLab7 : Form
    {
        public int[] int_mas;
        public int[] algmas;
        public int length_mas;
        public FormLab7()
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
            int_mas = arr;
            int K = Class1.Kol(arr, length);

            int[] resmas = new int[length];
            Class1.Set_mas(arr, K, resmas, out int j);
            Class1.Output_mas(resmas, j, dataGridView2);
            algmas = resmas;
            length_mas = j;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.AlgTask4(algmas, length_mas);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1.AlgTask8(algmas, length_mas);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1.AlgTask10(algmas, length_mas);
            Class1.Output_mas(algmas, length_mas, dataGridView3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1.AlgTask11(algmas, length_mas);
            Class1.Output_mas(algmas, length_mas, dataGridView4);
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

        private void button8_Click(object sender, EventArgs e)
        {
            Class1.Write_To_Word(int_mas);

        }
        private void button10_Click(object sender, EventArgs e)
        {
            Class1.Write_To_Excel(int_mas, algmas);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbooks books = app.Workbooks;
            Microsoft.Office.Interop.Excel._Workbook book = null;
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            book = books.Open(path + "\\Result.xlsm");
            app.Run((object)"Макрос1");
            app.ScreenUpdating = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Class1.Create_DB();
            Class1.Add_Struct();
            Class1.Write_To_DB(int_mas, int_mas.Length);
        }

    }
}
