using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car
{
    public partial class Form1 : Form
    {
        int x1 = 10;
        int x2 = 20;
        Point point = new Point(10, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x1 += 10;
            x2 += 10;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), x1, 20, 50, 20);
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), x2, 5, 20, 15);
            e.Graphics.FillEllipse(new SolidBrush(Color.Gold), x2 - 5, 35, 10, 10);
            e.Graphics.FillEllipse(new SolidBrush(Color.Gold), x2 + 20, 35, 10, 10);
            timer1.Start();
        }
    }
}
