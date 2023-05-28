using System;
using System.Linq;
using System.Windows.Forms;
using ArifmeticLibrary;

namespace ArifmeticCalculator
{
    public partial class FormLab1 : Form
    {

        public FormLab1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double temp;

            textBox1.Text = textBox1.Text.Contains('.') ? textBox1.Text.Replace('.', ',') : textBox1.Text; // заменяем точки на запятые

            // исключение ввода строк или любых других символов
            if (double.TryParse(textBox1.Text, out temp))
            {
                double inputed_value_x = Class1.Input(textBox1); // записываем значение ввода пользователя

                double processed = Class1.ProcessExpression(inputed_value_x); // расчет выражения

                Class1.ProcessExpression_1(inputed_value_x, out double y); // расчет выражения (out y)

                double z = 0;
                Class1.ProcessExpression_2(inputed_value_x, ref z); // расчет выражения (ref z)

                Class1.Output(textBox2, processed); // вывод результата в текст бокс
                Class1.Output(textBox3, y); // вывод результата в текст бокс
                Class1.Output(textBox4, z); // вывод результата в текст бокс
            } 
            else
            {
                MessageBox.Show("Произошла ошоибка при конвертации вашего введенного значения в double.", "Ошибка");
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            new FormMain().ShowDialog();
        }
    }
}
