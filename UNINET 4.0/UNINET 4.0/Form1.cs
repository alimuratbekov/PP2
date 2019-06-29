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
    public partial class Menu : Form
    {
        Uninet uninet;

        List<Student> students = new List<Student>();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            uninet = new Uninet();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Students.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
            students = xs.Deserialize(fs) as List<Student>;
            fs.Close();

            bool found = false;

            foreach (Student student in students)
            {
                if (textBox1.Text == student.login && textBox2.Text == student.password)
                {
                    found = true;
                    uninet.st = student;
                    uninet.ShowDialog();
                }
            }
            if (!found)
                MessageBox.Show("Неправильный логин или пароль");
            
        }
    }
}
