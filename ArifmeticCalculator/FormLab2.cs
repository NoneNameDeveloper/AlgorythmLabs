using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArifmeticLibrary;

namespace ArifmeticCalculator
{
    public partial class FormLab2 : Form
    {
        public FormLab2()
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
            double x, y, a, b;

            // замена точек на запятые в double
            TextBox[] tList = new TextBox[4]; 
            tList[0] = textBox1;
            tList[1] = textBox3;
            tList[2] = textBox4;
            tList[3] = textBox5;

            foreach (var t in tList)
            {
                if (t.Text.Contains('.')) 
                {
                    t.Text = t.Text.Replace('.', ',');
                }
            }


            if (double.TryParse(textBox1.Text, out x) && 
                (double.TryParse(textBox3.Text, out y)) && 
                (double.TryParse(textBox4.Text, out a)) && 
                (double.TryParse(textBox5.Text, out b)))
            {
                double res = Class1.ProcessExpression(x, y, a, b);

                Class1.Output(textBox2, res);
            }

            else
            {
                MessageBox.Show("Проверьте правильность введенных данных.");
            }
        }
    }
}
