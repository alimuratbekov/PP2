using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Snake
{
    class Wall:GameObject
    {
        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();
        }
        public void Walls()
        {
            body = new List<Point>();
            string filename = "walls.txt";
            StreamReader sr = new StreamReader(filename);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
            
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == '#')
                        body.Add(new Point(j, i));
                }
            
        }
    }
}
