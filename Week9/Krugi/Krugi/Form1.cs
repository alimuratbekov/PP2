using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krugi
{
    public partial class Form1 : Form
    {
        //bool mouseClicked;
        Bitmap bitmap;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        public int x, y;
        Random random = new Random();
        Color[] colors = new Color[] {Color.Red, Color.Blue, Color.Yellow, Color.Black, Color.Brown };

        private void timer1_Tick(object sender, EventArgs e)
        {
            int index = random.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 3);
            g.DrawEllipse(pen, x, y, 20, 20);

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
                x = e.Location.X;
                y = e.Location.Y;
                timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
