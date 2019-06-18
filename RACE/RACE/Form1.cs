using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RACE
{
    public partial class Form1 : Form
    {
        int x, y;
        char sym;
        int sz;
        int xBull, yBull;


        enum Dir
        {
            LEFT,
            RIGHT,
            NONE
        }
        Dir dir;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sz = 30;
            x = pictureBox1.Width/2 - sz;
            y = pictureBox1.Height - sz - 20;
            dir = Dir.NONE;
            pictureBox1.BackColor = Color.Coral;
            xBull = x + sz / 2;
            yBull = y - sz;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.FillRectangle(new SolidBrush(Color.White), x, y, sz, sz/2);

            e.Graphics.FillRectangle(new SolidBrush(Color.Black), xBull, yBull, sz / 2, sz / 2);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (dir)
            {
                case Dir.LEFT:
                    x-=5;
                    break;
                case Dir.RIGHT:
                    x+=5;
                    break;
                case Dir.NONE:
                    break;
            }
            pictureBox1.Refresh();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            sym = e.KeyChar;
            if (sym == 'a')
                dir = Dir.LEFT;
            if (sym == 'd')
                dir = Dir.RIGHT;

        }
    }
}
