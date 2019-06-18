using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Food:GameObject
    {
        public Food(int x, int y, string sign, ConsoleColor color):base(x, y, sign, color) { }
        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(1, 40);
            int y = random.Next(1, 20);
            body[0].x = x;
            body[0].y = y;
        }
    }
}
