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
    public partial class FormLab3 : Form
    {
        public FormLab3()
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
            // очищение DataGridView
            dataGridView1.Rows.Clear();

            double fromValue;
            double toValue;
            double stepValue;
            // замена точек на запятые в double
            TextBox[] tList = new TextBox[3];
            tList[0] = textBox1;
            tList[1] = textBox2;
            tList[2] = textBox3;


            foreach (var t in tList)
            {
                if (t.Text.Contains('.'))
                {
                    t.Text = t.Text.Replace('.', ',');
                }
            }


            if (double.TryParse(textBox1.Text, out fromValue) &&
                (double.TryParse(textBox2.Text, out toValue)) &&
                (double.TryParse(textBox3.Text, out stepValue)))
            {
                int negativeCount = 0;
                fromValue = Class1.Input(textBox1);
                toValue = Class1.Input(textBox2);
                stepValue = Class1.Input(textBox3);
                
                Class1.Tabulation(fromValue, toValue, stepValue, dataGridView1, out negativeCount);

                Class1.Output(textBox4, Convert.ToDouble(negativeCount));

            }
            else
            {
                MessageBox.Show("Введите верные значения!");
            }
        }


    }
}
