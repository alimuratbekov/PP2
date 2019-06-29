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

namespace UNINET_4._0
{
    public partial class Uninet : Form
    {

        public Student st = new Student();

        int order = 20;

        public Uninet()
        {
            InitializeComponent();
        }

        private void Uninet_Load(object sender, EventArgs e)
        {
            display(new Size(90, 20), new Size(10, 10), new Size(10, 10));
        }

        public void display(Size lbsz, Size tbsz, Size btnsz)
        {
            Label name = new Label();
            name.Text = st.name + " " + st.surname;
            name.Size = lbsz;
            name.Location = new Point(10, 10);
            Controls.Add(name);

            Label id = new Label();
            id.Text = st.id;
            id.Size = lbsz;
            id.Location = new Point(10, 40);
            Controls.Add(id);

            foreach (Discipline dis in st.dis_s)
            {
                order += 40;
                Label disname = new Label();
                disname.Text = dis.disname;
                disname.Location = new Point(60, order);
                Controls.Add(disname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            Discipline dis = new Discipline();
            dis.q1 = add.textBox3.Text;
            dis.q2 = add.textBox4.Text;
            dis.q3 = add.textBox5.Text;
            dis.q4 = add.textBox6.Text;
            dis.final = add.textBox7.Text;
            st.dis_s.Add(dis);
        }
    }
}
