using System;
using System.Data.OleDb;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace ArraysLibrary
{
    public class Class1
    {
        public static int[] result_mas;
        public static int InputInt(TextBox textBox)
        {
            return int.Parse(textBox.Text);
        }


        public static void Enter_mas(int[] mas, int length, int a, int b)
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
                mas[i] = rnd.Next(a, b);
        }


        public static void Output_mas(int[] mas, int length, DataGridView dataGridView)
        {
            dataGridView.ColumnCount = length;
            dataGridView.RowCount = 2;

            for (int i = 0; i < length; i++)
            {
                dataGridView.Rows[0].Cells[i].Value = "[" + i + "]";
                dataGridView.Rows[1].Cells[i].Value = mas[i];
            }
        }

        public static void Set_mas(int[] mas, int k, int[] rezmas, out int j)
        {
            j = 0;

            for (int i = 0; i < mas.Length; i++)
                if (mas[i] > k)
                {
                    rezmas[j] = i;
                    j++;
                }
        }

        public static int Kol(int[] mas, int length)
        {
            int min_elem = 10000000;

            for (int i = 0; i < length; i++)
            {
                if (mas[i] % 4 == 0 && mas[i] > 0)
                {
                    if (mas[i] < min_elem)
                    {
                        min_elem = Convert.ToInt32(mas[i]);
                    }
                }
            }

            return min_elem;
        }

        // 4 алгоритм, определение на монотонность
        public static void AlgTask4(int[] input_mas, int n)
        {
            int i = 1;
            int Flag = 1;

            while (i <= n - 1 && Flag == 1)
            {
                if (input_mas[i] >= input_mas[i + 1])
                    Flag = 0;
                else
                    i = i + 1;
            }

            if (Flag == 1)
                MessageBox.Show("Последовательность монотонно убывающая.");
            else
                MessageBox.Show("Последовательность не монотонно убывающая.");
        }

        // нахождение номера первого четного элемента
        public static void AlgTask8(int[] input_mas, int n)
        {
            int i = 0;
            int Flag = 0;

            while (i < n - 1 && Flag == 0)
            {
                if (input_mas[i] % 2 == 0)
                {
                    Flag = 1;
                    break;
                }
                else
                    i = i + 1;
            }

            if (Flag == 1)
                MessageBox.Show("Номер первого четного элемента: " + i.ToString());
            else
                MessageBox.Show("Нет четных элементов");
        }



        // сортировка бинарными вставками (10 алгоритм)
        public static void AlgTask10(int[] a, int n)
        {
            for (int i = 2; i < n; i++)
            {
                int x = a[i];
                int left = 1;
                int right = i - 1;

                while (left <= right)
                {
                    int m = (left + right) / 2;

                    if (x < a[m])
                        right = m - 1;
                    else
                        left = m + 1;

                }

                for (int j = i - 1; j < left; j++)
                {
                    a[j + 1] = a[j];
                }

                a[left] = x;
            }


        }


        // сортировка простым выбором (11 алгоритм)
        public static void AlgTask11(int[] a, int n)
        {
            for (int i = 1; i < n - 1; i++)
            {
                int k = i;
                int x = a[i];

                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < x)
                    {
                        k = j;
                        x = a[j];
                    }

                }
                a[k] = a[i];
                a[i] = x;
            }

        }

        // сортировка простым обменом (12 алгоритм)
        public static void AlgTask12(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j < i; j--)
                {
                    if (a[j - 1] > a[j])
                    {
                        int x = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = x;
                    }

                }
            }
        }

        // Создание базы данных (7 лабораторная работа)
        public static void Create_DB()
        {
            var k = new ADOX.Catalog();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;

            var path = System.IO.Path.GetDirectoryName(location);

            try
            {
                k.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Result.accdb;");

            }
            catch (System.Runtime.InteropServices.COMException exp)
            {

            }
            finally
            {
                k = null;
            }
        }
        // Создание таблицы в базе данных (7 лабораторная работа)
        public static void Add_Struct()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);

            var p = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Result.accdb;");
            p.Open();
            var c = new OleDbCommand("Create Table [result_arr]([Индекс] INTEGER, [Элемент] INTEGER)", p);
            try
            {
                c.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                var table = new OleDbCommand("DELETE FROM [result_arr]", p);
                table.ExecuteNonQuery();
            }
            p.Close();
        }
        // Запись в массива в базу данных (7 лабораторная работа)
        public static void Write_To_DB(int[] mas, int len)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            var p = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Result.accdb;");
            p.Open();
            for (int i = 0; i < len; i++)
            {
                var c = new OleDbCommand("INSERT INTO [result_arr] ([Индекс], [Элемент]) VALUES('" + i + "','" + mas[i] + "')", p);
                c.Connection = p;
                c.ExecuteNonQuery();
            }
            p.Close();
            MessageBox.Show("База данных создана", "Создание БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Запись двух массивов в Excel (7 лабораторная работа)
        public static void Write_To_Excel(int[] init_arr, int[] res_arr)
        {
            Excel.Application excelApp = new Excel.Application();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            workbook = excelApp.Workbooks.Open(path + "\\Result.xlsm");
            worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
            worksheet.Name = "Массив";
            worksheet.Cells[1, 1] = "Исходный массив";
            for (int i = 0; i < init_arr.Length; i++)
            {
                worksheet.Cells[2, i + 1] = "[" + i + "]";
                worksheet.Cells[3, i + 1] = init_arr[i];
            }
            worksheet.Cells[4, 1] = "Результирующий массив";
            for (int i = 0; i < res_arr.Length; i++)
            {
                worksheet.Cells[5, i + 1] = "[" + i + "]";
                worksheet.Cells[6, i + 1] = res_arr[i];
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        // Запись массива в Word (7 лабораторная работа)
        public static void Write_To_Word(int[] mas)
        {
            Word.Application app = new Word.Application();
            var Wrd = new Word.Application
            {
                Visible = true
            };
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf);
            Wrd.Selection.TypeText("Исходный массив");

            object t1 = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object t2 = Word.WdAutoFitBehavior.wdAutoFitContent;
            Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 2, mas.Length + 1, t1, t2);
            tbl.Cell(1, 1).Range.InsertAfter("Индекс");
            tbl.Cell(2, 1).Range.InsertAfter("Элемент");
            for (int i = 0; i < mas.Length; i++)
            {
                tbl.Cell(1, i + 2).Range.InsertAfter("[" + Convert.ToString(i) + "]");
                str = String.Format("{0:f0}", mas[i]);
                tbl.Cell(2, i + 2).Range.InsertAfter(str);
            }
        }

    }
}
