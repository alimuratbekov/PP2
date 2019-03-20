using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake:GameObject
    {
        public Snake(int x, int y, char sign, ConsoleColor color):base(x, y, sign, color) { }
        public void Move(ConsoleKeyInfo consoleKey)
        {
            for (int i=body.Count - 1; i>0 ; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            if (consoleKey.Key == ConsoleKey.UpArrow) body[0].y--;
            if (consoleKey.Key == ConsoleKey.DownArrow) body[0].y++;
            if (consoleKey.Key == ConsoleKey.RightArrow) body[0].x++;
            if (consoleKey.Key == ConsoleKey.LeftArrow) body[0].x--;
        }
        public bool isCollisionWithFood(Food food)
        {
            if (body[0].x == food.body[0].x && body[0].y == food.body[0].y)
            {
                return true;
            }
            return false;
        }
        public bool isCollisionWithWall(Wall wall)
        {
            foreach (Point p in wall.body)
            {
                if (p.x == wall.body[0].x && p.y == wall.body[0].y)
                    return true;
            }
            return false;
        }
        public bool isCollisionWithSnake()
        {
            for (int i = 0; i < body.Count; i++)
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            return false;
        }
    }
}
