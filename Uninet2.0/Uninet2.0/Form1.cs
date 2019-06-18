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
using System.IO;

namespace Uninet2._0
{
    public partial class Form1 : Form
    {
        public Student student = new Student();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fs1 = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
            student = xs.Deserialize(fs1) as Student;
            
            stName.Text = student.name + " " + student.surname;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            (sender as TextBox).Size = new Size(64, 46);
            int x = (sender as TextBox).Location.X;
            int y = (sender as TextBox).Location.Y;
            (sender as TextBox).Location = new Point(x - 10, y - 10);
        }
    }
}
