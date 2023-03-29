using System.Windows.Forms;

namespace ArifmeticLibrary
{
    public class Class1
    {
        /// <summary>
        /// Конвертирует и возвращает значение из TextBox 
        /// </summary>
        /// <param name="t">TextBox.Text</param>
        /// <returns>Значение из TextBox (double)</returns>
        public static double Input(TextBox t)
        {
            
            return Convert.ToDouble(t.Text);
        }

        /// <summary>
        /// Записыват параметр в TextBox
        /// </summary>
        /// <param name="t">TextBox.Text</param>
        /// <param name="value">Параметр, который записывается в t</param>
        public static void Output(TextBox t, double value)
        {
            t.Text = value.ToString();
        }

        /// <summary>
        /// Вывод данных в 2 столбца DataGridView
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dataGridView"></param>
        public static void OutputToDataDridView(double x, double y, DataGridView dataGridView)
        {
            dataGridView.Rows.Add(x.ToString("F1"), y.ToString("F5"));
        }


        /// <summary>
        /// Метод к 4 лабораторной работе для получения 
        /// элементов ряда и последующих манипуляций с ними
        /// </summary>
        /// <param name="x"></param>
        /// <param name="E"></param>
        /// <param name="Nmax"></param>
        /// <param name="dataGridView"></param>
        public static void ProcessExpressionLab4(double x, double E, int Nmax, DataGridView dataGridView)
        {
            double n = 1;
            double a = -x;

            while (Math.Abs(a) > E && n < Nmax)
            {
                VivodDGV(n, Math.Abs(a), dataGridView);
                a = -a * x / (n + 1);
                n++;
            }
        }


        /// <summary>
        /// Метод для 4 лабораторной работы для вывода 
        /// данных в dataGridView 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="dataGridView"></param>
        public static void VivodDGV(double n, double a, DataGridView dataGridView)
        {
            dataGridView.Rows.Add(n.ToString("F1"), a.ToString("F5"));
        }


        /// <summary>
        /// Расчет выражения из лабораторной
        /// работы номер 3 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double ProcessExpressionLab3(double x)
        {
            double res;
            if (x > 1.0)
                res = Math.Pow(Math.E, x);
            else if (x < 0.0)
                res = 2.0 * x - 1.0;
            else
                res = -1.0;

            return res;
        }


        /// <summary>
        /// функция вывода в окно таблицы всех значений
        /// с помощью цикла и возвращения количества
        /// отрицательных значений функции
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <param name="dataGridView"></param>
        /// <param name="negativeCount"></param>
        public static void Tabulation(double a, double b, double h, DataGridView dataGridView, out int negativeCount)
        {
            double x = a;
            negativeCount = 0;

            double n = Convert.ToInt32(Math.Round((b - a) / h) + 1);

            for (int i = 1; i < n; i ++)
            {
                double y = ProcessExpressionLab3(x);
                
                if (y < 0)
                    negativeCount++;

                OutputToDataDridView(x, y, dataGridView);
                x += h;
            }

        }

        /// <summary>
        /// Рассчитывает результат выражения
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Результат расчета выражения</returns>
        public static double ProcessExpression(double x)
        {
            double res = 1.1 * Math.Pow(Math.E, x) + Math.Abs(Math.Cos(Math.Sqrt(Math.PI * x))) - (4.0 / 9.0);
            return res;
        }

        /// <summary>
        /// Рассчитывает результат выражения
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y">s</param>
        public static void ProcessExpression_1(double x, out double y)
        {
            y = 1.1 * Math.Pow(Math.E, x) + Math.Abs(Math.Cos(Math.Sqrt(Math.PI * x))) - (4.0 / 9.0);
        }

        /// <summary>
        /// Рассчитывает результат выражения
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ProcessExpression_2(double x, ref double y)
        {
            y = 1.1 * Math.Pow(Math.E, x) + Math.Abs(Math.Cos(Math.Sqrt(Math.PI * x))) - (4.0 / 9.0);
        }

        /// <summary>
        /// Рассчитываем выражение, ветви из условий.
        /// Метод для Лабораторной работы №2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Результат рассчета выражения</returns>
        public static double ProcessExpression(double x, double y, double a, double b)
        {
            double result;

            if (x > 0.0 && y > 1.0)
            {
                double t_1 = Math.Pow(x, y);
                double t_2 = Math.Sin(x + y);
                double t_3 = Math.Pow(Math.E, a * x);

                double max = t_1;
                if (t_2 > max)
                    max = t_2;
                if (t_3 > max)
                    max = t_3;
                
                result = a + max;
            }

            else if (x > 0.0 && y < 1.0)
            {
                double value_1 = x / a;
                double value_2 = y / b;

                if (value_1 > value_2)
                    result = value_2;
                
                else 
                    result =  value_1;
            }
            else
                result =  Math.Pow(Math.Log10(x * x + a * a), 2.0);

            return result;

        }

    }
}