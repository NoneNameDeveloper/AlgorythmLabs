using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace DoubleArrayLibrary
{

    public class DoubleArrayClass
    {

        // ввод целого числа из текстобка
        public static int InputInt(TextBox textBox)
        {
            return int.Parse(textBox.Text); 
        }

        // генерация двумерного массива (8 лаба)
        public static void ArrayGenerate(int[,] mas, int n, int m)
        {
            Random rnd = new Random();

            for (int i = 0; i < n; i ++)
                for (int j = 0; j < m; j ++)
                    mas[i, j] = Convert.ToInt16(rnd.Next(0, 100));
        }

        // вывод двумерного массива в ЭУ
        // DataGridView (8 лаба)
        public static void Output_mas(int[,] mas, int n, int m, DataGridView dgv)
        {
            dgv.ColumnCount = m + 1;
            dgv.RowCount = n + 1;
            dgv.Rows[0].Cells[0].Value = "[" + n + "]" + "[" + m + "]";

            for (int i = 0; i < n; i++)
                dgv.Rows[i + 1].Cells[0].Value = "[" + i + "]";
            for (int j = 0; j < m; j++)
                dgv.Rows[0].Cells[j + 1].Value= "[" + j + "]";
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    dgv.Rows[i + 1].Cells[j + 1].Value = mas[i, j];

        }

        // вывод одномерного массива
        public static void Output_mas1(int[] mas, int length, DataGridView dataGridView)
        {
            dataGridView.ColumnCount = length;
            dataGridView.RowCount = 2;

            for (int i = 0; i < length; i++)
            {
                dataGridView.Rows[0].Cells[i].Value = "[" + i + "]";
                dataGridView.Rows[1].Cells[i].Value = mas[i];
            }
        }


        // поиск разница между максимальным и минимальным элементом в матрице
        public static int MaxMinRaznost(int[,] mas, int n, int m)
        {
            int min = mas[0, 0];
            int max = mas[0, 0];

            // Находим минимальный и максимальный элементы в матрице
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mas[i, j] < min)
                        min = mas[i, j];
                    if (mas[i, j] > max)
                        max = mas[i, j];
                }
            }

            // Вычисляем разницу между максимальным и минимальным элементами
            int raznost = max - min;

            return raznost;

        }

        // Формирование нового массива из элементов исходной матрицы, значения
        // которых бльше найденной разности из метода MaxMinRaznost()
        public static void GenerateArr(int[,] matrix, int n, int m, int k, int[] resmas, out int g)
        {
            g = 0;

            // Формируем новый массив из элементов исходной матрицы, значения которых больше найденной разности
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > k)
                        resmas[g++] = matrix[i, j];
        }

        // Создание базы данных
        public static void Create_DB()
        {
            var k = new ADOX.Catalog();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            try
            {
                k.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Matrix.accdb");
                MessageBox.Show("База данных \"Matrix\" создана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.COMException exp)
            {
                MessageBox.Show("База данных \"Matrix\" уже создана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                k = null;
            }
        }

        // Метод создания структуры в базе данныхх
        public static void CreateStructDB(int columns)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            var Connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Matrix.accdb");
            Connect.Open();
            String Col = "CREATE TABLE [matrix] ([Rows] counter";
            for (int i = 0; i < columns; i++)
                Col = Col + ", [" + "Col" + Convert.ToString(i + 1) + "] varchar(10)";
            var Command = new OleDbCommand(Col + ")", Connect);
            try
            {
                Command.ExecuteNonQuery();
                MessageBox.Show("Структура таблицы \"matrix\" записана в базу данных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                var table = new OleDbCommand("DELETE FROM [matrix]", Connect);
                table.ExecuteNonQuery();
                MessageBox.Show("Структура таблицы \"matrix\" записана в базу данных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Connect.Close();
        }

        // Метод выполняющий запрос на заполнение базы данных
        public static void CommDB(string commandString)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            var Connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Matrix.accdb");
            Connection.Open();
            var Command = new OleDbCommand("" + commandString);
            Command.Connection = Connection;
            Command.ExecuteNonQuery();
            Connection.Close();
        }


        // Метод записи матрицы в базу данных
        public static void AddToDB(int[,] mas, int rows, int columns)
        {
            String cmdString;
            String cmdString2;
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            var Connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path.ToString().Replace("\\", "\\\\") + "\\Matrix.accdb");
            Connect.Open();
            for (int i = 0; i < rows; i++)
            {
                cmdString = "INSERT INTO  [matrix] ([Rows]";
                cmdString2 = ") VALUES (" + "'" + Convert.ToString(i + 1) + "'";
                for (int j = 0; j < columns; j++)
                {
                    cmdString = cmdString + ", [Col" + Convert.ToString(j + 1) + "]";
                    cmdString2 = cmdString2 + ", '" + Convert.ToString(mas[i, j]) + "'";
                }
                cmdString2 = cmdString2 + ")";
                CommDB(cmdString + cmdString2);
            }
            Connect.Close();
            MessageBox.Show("В таблицу \"matrix\" записана матрица.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод записи матрицы в блокнот
        public static void Write_To_Note(int[,] matrix, int[] mas, int rows, int columns, int length)
        {
            StreamWriter res = File.CreateText("Вывод матрицы и массива.txt");
            res.WriteLine("Матрицы");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    res.Write(string.Format("{0, 6}", matrix[i, j] + "\t"));
                res.WriteLine();
            }
            res.WriteLine("Результирующий массив");
            res.WriteLine("Индекс\tЭлемент");
            for (int i = 0; i < length; i++)
                res.WriteLine(i + "\t\t" + string.Format("{0, 7}", mas[i]));
            res.Close();

            MessageBox.Show("Матрца успешно записана в Word!");
        }

        // Запись в Excel
        public static void Write_To_Excel(int[,] matrix, int[] res_arr, int rows, int columns, int length)
        {
            Excel.Application excelApp = new Excel.Application();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(location);
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            workbook = excelApp.Workbooks.Open(path + "\\Matrix.xlsx");
            worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
            worksheet.Name = "Матрица и массив";
            for (int i = 0; i < columns; i++)
                worksheet.Cells[1, i + 2] = "Столбец " + (i + 1);
            for (int i = 0; i < rows; i++)
            {
                worksheet.Cells[i + 2, 1] = "Строка " + (i + 1);
                for (int j = 0; j < columns; j++)
                    worksheet.Cells[i + 2, j + 2] = matrix[i, j];
            }

            worksheet.Cells[rows + 4, 1] = "Результирующий массив";
            for (int i = 0; i < length; i++)
            {
                worksheet.Cells[rows + 5, i + 1] = "[" + i + "]";
                worksheet.Cells[rows + 6, i + 1] = res_arr[i];
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;

            MessageBox.Show("Матрица успешно записана в Excel!");
        }

        // Запись в Word
        public static void Write_To_Word(int[,] matrix, int[] mas, int rows, int columns, int length, int g)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            var Wrd = new Microsoft.Office.Interop.Word.Application
            {
                Visible = true
            };
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf);
            Wrd.Selection.TypeText("Матрица");
            object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;
            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, columns + 1, rows + 1, t1, t2);
            for (int i = 0; i < columns; i++)
                tbl.Cell(i + 2, 1).Range.InsertAfter("[" + Convert.ToString(i) + "]");
            for (int j = 0; j < rows; j++)
                tbl.Cell(1, j + 2).Range.InsertAfter("[" + Convert.ToString(j) + "]");
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                {
                    str = String.Format("{0, 4}", matrix[i, j]);
                    tbl.Cell(i + 2, j + 2).Range.InsertAfter(str);
                }
            Object t3 = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            Object add_str = columns + 2;
            Wrd.Selection.MoveDown(t3, add_str, inf);
            Wrd.Selection.TypeText("Разница между максималным и минимальным элементом в матрице: " + g + "\nРезультирующий массив\n");
            tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 2, length, t1, t2);
            for (int i = 0; i < length; i++)
            {
                tbl.Cell(1, i + 1).Range.InsertAfter("[" + Convert.ToString(i) + "]");
                str = String.Format("{0, 3}", mas[i]);
                tbl.Cell(2, i + 1).Range.InsertAfter(str);
            }

            MessageBox.Show("Матрца успешно записана в Word!");
        }
    }
}
