using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Black, Color.Yellow, Color.Green, Color.HotPink, Color.LightCyan, Color.Magenta };
        int index;
        Color color;
        Button btn;

        private void Form1_Load(object sender, EventArgs e)
        {
            int sz = 80;
            int x = 10;
            int y = 10;
            int d = 10;

            for (int i=0;i<4;i++)
            {
                for (int j=0;j<4;j++)
                {
                    btn = new Button();
                    btn.Size = new Size(sz, sz);
                    btn.Location = new Point(i * sz + x + d, j * sz+ y + d);
                    btn.Click += Btn_Clicked;
                    Controls.Add(btn);
                }
            }
            
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            index = random.Next(0, colors.Length - 1);
            color = colors[index];
            
        }
    }
}
