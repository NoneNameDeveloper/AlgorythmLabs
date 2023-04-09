namespace ArrayLibrary
{
    public class Class1
    {

        public static int InputInt(TextBox textBox)
        {
            return int.Parse(textBox.Text);
        }


        public static void Enter_mas(double[] mas, int length, int a, int b)
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
                mas[i] = rnd.Next(a, b);
        }


        public static void Output_mas(double[] mas, int length, DataGridView dataGridView)
        {
            dataGridView.ColumnCount = length;
            dataGridView.RowCount = 2;

            for (int i = 0; i < length; i++)
            {
                dataGridView.Rows[0].Cells[i].Value = "[" + i + "]";
                dataGridView.Rows[1].Cells[i].Value = mas[i];
            }
        }

        public static void Set_mas(double[] mas, int k, double[] rezmas, out int j)
        {
            j = 0;

            for (int i = 0; i < mas.GetLength(0); i++)
                if (mas[i] > k)
                {
                    rezmas[j] = i;
                    j++;
                }
        }

        public static int Kol(double[] mas, int length)
        {
            int min_elem = 10000000;

            for (int i = 0;  i < length; i++)
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
    }

}