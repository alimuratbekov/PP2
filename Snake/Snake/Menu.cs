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

namespace Snake
{
    public partial class Menu : Form
    {
        public string lvl;
        public Color color;
        public string size;
        public int sz;

        Form1 form1 = new Form1();

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lvl = (sender as Button).Text;
            if (lvl == "Easy")
                form1.speed = 50;
            else if (lvl == "Normal")
                form1.speed = 30;
            else if (lvl == "Hard")
                form1.speed = 10;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            color = (sender as Button).BackColor;
            form1.color = this.color;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            size = (sender as Button).Text;
            if (size == "Small")
                sz = 10;
            if (size == "Normal")
                sz = 15;
            if (size == "BIG")
                sz = 20;
            form1.sz = this.sz;


        }
    }
}
