using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNINET_3._0
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();


        public Form2()
        {
            InitializeComponent();
        }

        private void Credits_TextChanged(object sender, EventArgs e)
        {
            int x;
            string s = (sender as TextBox).Text;
            if (!Int32.TryParse(s, out x) && (sender as TextBox).Text != "")
                MessageBox.Show("Можно вводить только числа!");
            if ((x > 4 || x < 1) && (sender as TextBox).Text != "")
                MessageBox.Show("Недопустимое количество кредитов");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            int x;
            string s = (sender as TextBox).Text;
            if (!Int32.TryParse(s, out x) && (sender as TextBox).Text != "")
                MessageBox.Show("Можно вводить только числа!");
            if (x > 15)
                MessageBox.Show("Максимум 15 баллов за куиз!");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int x;
            string s = (sender as TextBox).Text;
            if (!Int32.TryParse(s, out x) && (sender as TextBox).Text != "")
                MessageBox.Show("Можно вводить только числа!");
            if (x > 40)
                MessageBox.Show("Максимум 40 баллов за файнал");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
