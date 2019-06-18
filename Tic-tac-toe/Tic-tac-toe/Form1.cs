using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 1;
        Point prevX = new Point(), curX = new Point();
        Point prevO = new Point(), curO = new Point();
        int combX = 1, combO = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (i % 2 != 0)
            {
                (sender as Button).Text = "X";
                curX = (sender as Button).Location;
                if (curX.X == prevX.X || curX.Y == prevX.Y) combX++;
                else combX = 1;
                prevX = curX;
            }
            if (i % 2 == 0)
            {
                (sender as Button).Text = "O";
                curO = (sender as Button).Location;
                if (curO.X == prevO.X || curO.Y == prevO.Y) combO++;
                else combO = 1;
                prevO = curO;
            }
            i++;
            if (combX == 3) MessageBox.Show("X Win!");
            if (combO == 3) MessageBox.Show("O Win!");
        }
    }
}
