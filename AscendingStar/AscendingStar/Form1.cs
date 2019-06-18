using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendingStar
{
    public partial class Form1 : Form
    {
        public int x, y;
        public int sz;
        Color[] colors;
        Color color;

        Random random = new Random();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            x = random.Next(0, pictureBox1.Width);
            y = random.Next(0, pictureBox1.Height);
            colors = new Color[] { Color.Black, Color.Red, Color.Blue, Color.Brown,Color.Yellow, Color.Green, Color.Gray };
            sz = 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int index = random.Next(0, colors.Length - 1);
            color = colors[index];
            sz += 5;

            if (sz >=100)
            {
                x = random.Next(0, pictureBox1.Width);
                y = random.Next(0, pictureBox1.Height);
                sz = 10;
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(color), x - sz, y - sz, 2*sz, 2*sz);
        }
    }
}
