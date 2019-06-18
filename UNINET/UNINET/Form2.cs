using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNINET
{
    public partial class Edit : Form
    {
        public Student student = new Student();

        private void Edit_Load(object sender, EventArgs e)
        {
        }
        
        public void SaveButton_Click(object sender, EventArgs e)
        {
            student.q1 = this.textBox1.Text;
            student.q2 = textBox2.Text;
            student.q3 = textBox3.Text;
            student.q4 = textBox4.Text;
            student.fin = textBox5.Text;
        }

        public Edit()
        {
            InitializeComponent();
        }

    }
}
