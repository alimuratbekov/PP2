using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char oper;
        double a = 0, b = 0;
        int cnt = 0;

        private void button6_Click(object sender, EventArgs e) // набор чисел в textBox
        {
            if (textBox1.Text == "0" && (sender as Button).Text != ",")
                textBox1.Clear();
            textBox1.Text += (sender as Button).Text;
        }

        private void button2_Click(object sender, EventArgs e) // операции над числами
        {
            a = Convert.ToDouble(textBox1.Text);
            oper = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cnt = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(textBox1.Text)));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Pow(Convert.ToDouble(textBox1.Text),2));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text += "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (cnt==0 && textBox1.Text != "")
            {
                textBox1.Text += (sender as Button).Text;
            }
            cnt++;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Sin(int.Parse(textBox1.Text))).ToString();
        }

        private void button23_Click(object sender, EventArgs e) // binaryZHOPA
        {
            textBox1.Text = Convert.ToString(int.Parse(textBox1.Text), 2);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) / 100).ToString();
        }

        private void button19_Click(object sender, EventArgs e) // вывод ответа
        {
            b = Convert.ToDouble(textBox1.Text);
            if (oper == '+')
            {
                textBox1.Text = Convert.ToString(a + b);
            }
            if (oper == '-')
            {
                textBox1.Text = Convert.ToString(a - b);
            }
            if (oper == '*')
            {
                textBox1.Text = Convert.ToString(a * b);
            }
            if (oper == '/')
            {
                textBox1.Text = Convert.ToString(a / b);
            }
        }
    }
}
