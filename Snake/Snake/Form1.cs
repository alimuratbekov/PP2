using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Snake
{
    public partial class Form1 : Form
    {
        Dir dir;
        List<Point> snake;
        public Color color = Color.Black;

        Point pFood;
        Random random;

        public int sz = 15;
        public int speed = 30;

        int progress;

        enum Dir
        {
            None,
            Up,
            Down,
            Right,
            Left
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dir = Dir.None;
            snake = new List<Point>();
            snake.Add(new Point(10,10));
            
            pFood = new Point(100, 100);

            random = new Random();

            progress = 0;
            textBox1.Text = progress.ToString();
            //sz = 10;
            //sz = 15;

            timer1.Interval = speed;

            timer1.Start();
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int headx = snake[0].X, heady = snake[0].Y;
            switch (dir)
            {
                case Dir.Up:
                    heady-=5;
                    if (heady < 0)
                        heady = pictureBox1.Height - 1;
                    break;
                case Dir.Down:
                    heady+=5;
                    if (heady >= pictureBox1.Height)
                        heady = 0;
                    break;
                case Dir.Right:
                    headx+=5;
                    if (headx >= pictureBox1.Width)
                        headx = 0;
                    break;
                case Dir.Left:
                    headx-=5;
                    if (headx < 0)
                        headx = pictureBox1.Width - 1;
                    break;
                case Dir.None:
                    break;
            }

            Point p = new Point(headx, heady);
            snake.Insert(0, p);

            if ((snake[0].X >= pFood.X - sz && snake[0].X <= pFood.X + sz) && (snake[0].Y >= pFood.Y - sz && snake[0].Y <= pFood.Y + sz))
            {
                progress += 10;
                textBox1.Text = progress.ToString();
                pFood = new Point(random.Next(pictureBox1.Width - sz), random.Next(pictureBox1.Height - sz));
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            for (int i = 2; i < snake.Count; i++) 
            {
                if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                {
                    timer1.Stop();
                    MessageBox.Show("LOSHARA!");
                    Close();
                }
            }

            pictureBox1.Refresh();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sym = e.KeyChar;
            switch (sym)
            {
                case 'w':
                    if (dir != Dir.Down)
                        dir = Dir.Up;
                    break;
                case 's':
                    if (dir != Dir.Up)
                        dir = Dir.Down;
                    break;
                case 'a':
                    if (dir != Dir.Right)
                        dir = Dir.Left;
                    break;
                case 'd':
                    if (dir != Dir.Left)
                        dir = Dir.Right;
                    break;
                case 'p':
                    dir = Dir.None;
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Green), pFood.X, pFood.Y, sz, sz);

            e.Graphics.FillRectangle(new SolidBrush(color), snake[0].X, snake[0].Y, sz, sz);
            for (int i = 0; i < snake.Count; i++)
                e.Graphics.FillRectangle(new SolidBrush(color), snake[i].X, snake[i].Y, sz, sz);
        }
    }
}
