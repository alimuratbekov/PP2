using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public abstract class GameObject
    {
        protected char label;
        protected List<Point> locations;

        public GameObject(char label)
        {
            this.label = label;
            locations = new List<Point>();
        }

        public char GetLebel()
        {
            return label;
        }

        public void AddPoint(Point p)
        {
            locations.Add(p);
        }

        public void PrependPoint(Point p)
        {
            locations.Add(p);
            Point t = locations[0];

            locations[0] = locations[locations.Count - 1];
            locations[locations.Count - 1] = t;
        }

        public bool Overlaps(int x, int y)
        {
            foreach (var p in locations)
            {
                if (p.x == x && p.y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public void ClearLocations()
        {
            locations.Clear();
        }

        public virtual void Draw()
        {
            foreach(var p in locations)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(label);
            }
        }

        public void Clear()
        {
            foreach(var p in locations)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(' ');
            }
        }
    }
}
