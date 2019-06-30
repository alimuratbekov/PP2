using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Person: GameObject
    {
        // переменные при помощи которых задаётся направление персонажа
        // (1, 0) - направо; (-1, 0) - налево; (0, 1) - вверх; (0, -1) - вниз
        private int directionX = 0;
        private int directionY = 0;

        public Person(char label) : base(label) {}
        
        // функция для направления движения
        public void move(int dirX, int dirY)
        {
            directionX = dirX;
            directionY = dirY;
        }

        // отрисовка персонажа
        public override void Draw()
        {
            // координата "головы"
            Point head = locations[0];

            // движение работает следующим образом: к координате "головы" суммируется значение направления движения...
            // ... затем эта новая координата сохраняется, а прошлая стирается. 
            // Например координата персонажа (10,10), а направление направо (directionX = 1): к head.x (10) прибавляется directionX (1)...
            // ... таким образом, новая координата персонажа (11, 10). Персонаж отрисовывается заново при помощи функции draw()
            int newX = head.x + directionX;
            int newY = head.y + directionY;

            for (int i = locations.Count - 1; i > 0; i--)
            {
                locations[i] = locations[i - 1];

            }

            locations[0] = new Point(newX, newY);

            base.Draw();
        }

        // функция столкновения со стеной
        public bool IsWallCollision(Wall wall)
        {
            // если координата персонажа совпадает с координатой стены, то столкновение со стеной = истинно
            Point head = locations[0];
            return wall.Overlaps(head.x, head.y);
        }

        // функция столкновения с выходом
        public bool IsExitCollision(Exit exit)
        {
            // если координата персонажа совпадает с координатой выхода, то столкновение с выходом = истинно
            Point head = locations[0];
            return exit.Overlaps(head.x, head.y);
        }
    }
}
