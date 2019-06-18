using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Saved
    {
        public string Susername;
        public int Sscore;
        public List<Point> Sbody;

        public Saved() { }
        public Saved(string username, int score, List<Point> body)
        {
            Susername = username;
            Sscore = score;
            Sbody = body;
        }
        public void print()
        {
            Console.WriteLine(Susername + Sscore);
        }
    }
}
