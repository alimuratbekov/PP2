using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics gBitmap;
        bool mouseClicked;
        Point prevPoint, curPoint;
        Color penColor;
        int penThickness;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            mouseClicked = false;
            penColor = Color.Black;
            penThickness = 3;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                curPoint = e.Location;
                gBitmap.DrawLine(new Pen(penColor, penThickness), prevPoint, curPoint);
                prevPoint = curPoint;
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            penColor = (sender as Button).BackColor;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            penThickness = trackBar1.Value;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            penColor = pictureBox1.BackColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
