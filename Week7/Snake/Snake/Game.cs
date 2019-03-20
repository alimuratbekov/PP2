using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Game
    {
        public Snake snake;
        public Food food;
        public Wall wall;

        bool isAlive;
        List<GameObject> g_objects;

        public Game()
        {
            isAlive = true;
            snake = new Snake(10, 10, 'O', ConsoleColor.Yellow);

            food = new Food(0 , 0, 'o', ConsoleColor.Cyan);
            food.Generate(snake, wall);

            wall = new Wall('#', ConsoleColor.Green);
            wall.LoadLevel();

            g_objects = new List<GameObject>();
            g_objects.Add(snake);
            g_objects.Add(food);

            Console.CursorVisible = false;
        }
        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape && isAlive)
            {
                snake.Move(consoleKey);
                Draw();
                consoleKey = Console.ReadKey();
                if (snake.isCollisionWithFood(food))
                {
                    snake.body.Add(new Point(0, 0));
                    food.Generate(snake, wall);
                    
                }
                if (snake.isCollisionWithWall(wall))
                {
                    isAlive = false;
                }
                if (snake.isCollisionWithSnake())
                {
                    isAlive = false;
                }
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.Write("GAME OVER");
                Console.ReadKey();
            }
        }
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
            {
                g.Draw();
            }
        }
    }
}
