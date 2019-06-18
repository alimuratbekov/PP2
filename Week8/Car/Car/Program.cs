using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Car
{
    class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Thread thread = new Thread(Ride);

            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LET'S GOOOOO!");

            Console.ReadKey();

            thread.Start();

        }
        static void Ride()
        {
            List<Point> car = new List<Point>();

            StreamReader sr = new StreamReader("car.txt");
            string[] rows = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == '*')
                        car.Add(new Point(j, i));
                }
            }

            for (int i=0;i<50;i++)
            {
                Console.Clear();
                foreach(Point p in car)
                {
                    p.x++;
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write('*');
                }
                Thread.Sleep(50);
            }
        }
    }
}
