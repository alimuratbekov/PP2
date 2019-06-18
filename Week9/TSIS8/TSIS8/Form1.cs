using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSIS8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.DarkBlue;
            SolidBrush brush = new SolidBrush(Color.Yellow);
            Graphics graphics;
            graphics = this.CreateGraphics();

            Random random = new Random();
            SolidBrush brushOfCircles1 = new SolidBrush(Color.White);
            Point starPoints = new Point();

            for (int i = 0; i < 10; i++)
            {
                starPoints.X = random.Next(0, 400);
                starPoints.Y = random.Next(0, 200);
                graphics.FillEllipse(brushOfCircles1, starPoints.X, starPoints.Y, 20, 20);
            }

            SolidBrush brushOfStar = new SolidBrush(Color.Red);
            Point asterPoints = new Point();

            for (int i = 0; i < 7; i++)
            {
                asterPoints.X = random.Next(0, 600);
                asterPoints.Y = random.Next(0, 200);
                Point[] pointsOfRectangleInStar = { new Point(50 + asterPoints.X, 85 + asterPoints.Y), new Point(80 + asterPoints.X, 40 + asterPoints.Y), new Point(110 + asterPoints.X, 85 + asterPoints.Y) };
                graphics.FillPolygon(brushOfStar, pointsOfRectangleInStar);
                Point[] pointsOfRectangleInStarReversed = { new Point(50 + asterPoints.X, 55 + asterPoints.Y), new Point(80 + asterPoints.X, 100 + asterPoints.Y), new Point(110 + asterPoints.X, 55 + asterPoints.Y) };
                graphics.FillPolygon(brushOfStar, pointsOfRectangleInStarReversed);
            }

            SolidBrush brushOfBullet = new SolidBrush(Color.Green);
            graphics.FillRectangle(brushOfBullet, 245, 40, 10, 10);

            Point[] bulletPoints1 =
            {
                new Point(245,40),new Point(255,40),new Point(250,25)
            };
            graphics.FillPolygon(brushOfBullet, bulletPoints1);

            Point[] bulletPoints2 =
            {
                new Point(245, 50),new Point(255, 50), new Point(250, 65)
            };
            graphics.FillPolygon(brushOfBullet, bulletPoints2);

            Point[] bulletPoints3 =
            {
                new Point(245,40),new Point(230,45), new Point(245,50)
            };
            graphics.FillPolygon(brushOfBullet, bulletPoints3);

            Point[] bulletPoints4 =
            {
                new Point(255,40), new Point(270,45),new Point(255,50)
            };
            graphics.FillPolygon(brushOfBullet, bulletPoints4);

            Point[] pointsOfOctagon =
                {
                                new Point(200, 120),
                                new Point(245, 145),
                                new Point(290, 120),
                                new Point(290, 95),
                                new Point(245, 70),
                                new Point(200, 95)
                };
            graphics.FillPolygon(brush, pointsOfOctagon);

            SolidBrush brushOfGun = new SolidBrush(Color.Green);
            Point[] pointsOfGun =
            {
                new Point(245,75),new Point(255,90),new Point(235,90)
            };
            graphics.FillPolygon(brushOfGun, pointsOfGun);


            graphics.FillRectangle(brushOfGun, 240, 90, 10, 40);

            SolidBrush br = new SolidBrush(Color.White);
            graphics.FillRectangle(br, Width - 125, Height - 320, 100, 15);
            string text = "Level:1  Score:200  Live:***";
            using (Font font = new Font("Arial", 5, FontStyle.Bold, GraphicsUnit.Point))
            {
                RectangleF recf = new RectangleF(Width - 125, Height - 320, 100, 15);

                SolidBrush brush5 = new SolidBrush(Color.White);
                graphics.FillRectangle(brush5, Width - 125, Height - 320, 100, 15);
                graphics.DrawRectangle(Pens.Yellow, Rectangle.Round(recf));
                graphics.DrawString(text, font, Brushes.Black, recf);
            }

        }
    }
}
