using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dino
{
    public partial class Form1 : Form
    {
        static int sz = 50;
        int x = 10, y = (3 * pictureBox1.Height) / 4 - sz;
        int h2 = (3 * pictureBox1.Height) / 4 - sz - 250;
        enum st
        {
            JumpUp,
            JumpDown,
            Sit,
            None
        }

        Bitmap bitmap;
        Graphics g;

        st state = st.None;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            g.DrawLine(new Pen(Color.Black), 0, (3 * pictureBox1.Height)/4, pictureBox1.Width-1, (3 * pictureBox1.Height)/4);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (state == st.JumpUp)
            {
                y -= 5;

                if(y >= h2)
                {
                    state = st.JumpDown;
                }
            }
            else if (state == st.JumpDown)
            {
                y += 5;
                if(y == (3 * pictureBox1.Height) / 4)
                {
                    state = st.None;
                }
            }
            pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //timer1.Start();
            }
            else if (e.KeyCode == Keys.Up)
            {
                state = st.JumpUp;
            }
            else if(e.KeyCode == Keys.Down)
            {
                state = st.Sit;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(state == st.Sit)
            {
                state = st.None;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (state == st.None)
            {
                y = (3 * pictureBox1.Height) / 4 - sz;
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, sz, sz);
            }
            else if (state == st.Sit)
            {
                y = (3 * pictureBox1.Height) / 4 - (sz*2)/3;
                
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, sz, (sz * 2) / 3);
            }
            else if (state == st.JumpDown || state == st.JumpUp)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, sz, sz);
            }
        }
    }
}
