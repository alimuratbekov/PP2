using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake:GameObject
    {
        enum Direction
        {
            NONE,
            UP,
            DOWN,
            RIGHT,
            LEFT
        }
        Direction direction = Direction.NONE;
        public Snake(int x, int y, char sign, ConsoleColor color):base(x, y, sign, color) { }

        public void Move()
        {
            if (direction == Direction.NONE)
                return;

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (direction == Direction.UP) body[0].y--;
            if (direction == Direction.DOWN) body[0].y++;
            if (direction == Direction.LEFT) body[0].x--;
            if (direction == Direction.RIGHT) body[0].x++;
        }

        public void ChangeDirection(ConsoleKeyInfo consoleKey)
        {
            if (consoleKey.Key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (consoleKey.Key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            if (consoleKey.Key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (consoleKey.Key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
        }

        public bool IsCollisionWithItself()
        {
            for (int i=1;i<body.Count;i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
    }
}
