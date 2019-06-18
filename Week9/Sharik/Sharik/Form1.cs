using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharik
{
    public partial class Form1 : Form
    {
        Graphics g;
        static double x = 200, y = 200;
        int x1 = (int)(x), y1 = (int)(y); 
        double t = 1, v = 10;
        double a = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += 1;
            x = v * Math.Cos(a)*t;
            y = v * Math.Sin(a) * t - 9.8 * t * t / 2;

            pictureBox1.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), x1 + (int)(x), y1 + (int)(-y), 10, 10);
            timer1.Start();
        }
    }
}
