using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Person: GameObject
    {
        
        private int directionX = 1;
        private int directionY = 0;

        public Person(char label) : base(label) {}

        public void move(int dirX, int dirY)
        {
            directionX = dirX;
            directionY = dirY;
        }

        public override void Draw()
        {
            Point head = locations[0];

            int newX = head.x + directionX;
            int newY = head.y + directionY;

            for (int i = locations.Count - 1; i > 0; i--)
            {
                locations[i] = locations[i - 1];

            }

            locations[0] = new Point(newX, newY);

            base.Draw();
        }

        public bool IsWallCollision(Wall wall)
        {
            Point head = locations[0];
            return wall.Overlaps(head.x, head.y);
        }

        public bool IsExitCollision(Exit exit)
        {
            Point head = locations[0];
            return exit.Overlaps(head.x, head.y);
        }
    }
}
