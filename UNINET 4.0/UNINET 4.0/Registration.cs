using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace UNINET_4._0
{
    public partial class Registration : Form
    {
        Menu menu = new Menu();

        Student student;
        List<Student> students = new List<Student>();

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            student = new Student();

            FileStream fs = new FileStream("Students.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
            students = xs.Deserialize(fs) as List<Student>;

            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student.login = textBox1.Text;
            if (textBox2.Text == textBox3.Text)
            {
                student.password = textBox3.Text;
                student.name = textBox4.Text;
                student.surname = textBox5.Text;
                student.id = textBox6.Text;

                students.Add(student);

                FileStream fs = new FileStream("Students.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
                xs.Serialize(fs, students);
                fs.Close();

                Close();
            }
            else
                MessageBox.Show("Пароли не соответствуют!");
        }
    }
}
