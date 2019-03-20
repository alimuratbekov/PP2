using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Snake
{
    class Wall:GameObject
    {
        enum GameLevel
        {
            First
        }
        GameLevel gamelevel = GameLevel.First;
        public Wall(char sign, ConsoleColor color):base(0 ,0, sign, color)
        {
            body = new List<Point>();
        }
        public void Walls(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string s = "";
            int y = 0;
            while ((s = sr.ReadLine()) != null)
            {
                for (int x = 0;x<s.Length;x++)
                {
                    if (s[x] == '#') body.Add(new Point(x, y));
                }
                y++;
            }
            sr.Close();
        }
        public void LoadLevel()
        {
            body = new List<Point>();
            if (gamelevel == GameLevel.First)
            {
                Walls("walls.txt");
            }
        }
    }
}
