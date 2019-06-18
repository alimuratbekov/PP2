using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UNINET
{
    public partial class MainMenu : Form
    {
        Edit edit = new Edit();
        public Student student = new Student();

        public string disname;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void click_Click(object sender, EventArgs e)
        {
            disname = (sender as Label).Text;
            edit.label1.Text = this.disname;
            edit.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.student = edit.student;
            if (disname == "PP II")
            {
                textBox1.Text = student.q1;
                textBox5.Text = student.q2;
                textBox9.Text = student.q3;
                textBox13.Text = student.q4;
            }
            else if (disname == "History")
            {
                textBox2.Text = student.q1;
                textBox6.Text = student.q2;
                textBox10.Text = student.q3;
                textBox14.Text = student.q4;
            }
            else if (disname == "Calculus II")
            {
                textBox3.Text = student.q1;
                textBox7.Text = student.q2;
                textBox11.Text = student.q3;
                textBox15.Text = student.q4;
            }
            else if (disname == "Physics I")
            {
                textBox4.Text = student.q1;
                textBox8.Text = student.q2;
                textBox12.Text = student.q3;
                textBox16.Text = student.q4;
            }
        }
    }
}
