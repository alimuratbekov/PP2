using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoKvadratu
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = 0, y = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x < pictureBox1.Width && y == 0)
                x += 15;
            if (x == pictureBox1.Width - 1 && y < pictureBox1.Height)
                y += 15;
            if (x >= 0 && y == pictureBox1.Height - 1)
                x -= 15;
            if (x == 0 && y >= 0)
                y -= 15;

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 10, 10);
            timer1.Start();
        }
    }
}
