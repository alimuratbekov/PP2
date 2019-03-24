using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    class Game
    {
        public bool isAlive;
        public string username;
        public int score = 0;

        List<GameObject> g_objects;

        public Snake snake;
        public Food food;
        public Wall wall;

        public Game()
        {
            g_objects = new List<GameObject>();

            isAlive = true;

            snake = new Snake(10, 10, 'o', ConsoleColor.Blue);

            food = new Food(0, 0, 'O', ConsoleColor.Green);
            food.Generate();

            wall = new Wall('#', ConsoleColor.Red);
            wall.Walls();

            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();

            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);

            Console.CursorVisible = false;
        }
        public void Start()
        {
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Press any button to start.");

            ConsoleKeyInfo consoleKey = Console.ReadKey();

            Thread thread = new Thread(MoveSnake);
            thread.Start();

            while (isAlive && consoleKey.Key != ConsoleKey.Escape)
            {
                consoleKey = Console.ReadKey();
                snake.ChangeDirection(consoleKey);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("GAME OVER! " + username + ", your score is: " + score);
            Console.ReadKey();
        }

        public void MoveSnake()
        {
            while (isAlive)
            {
                snake.Move();
                if (snake.IsCollisionWithObject(food))
                {
                    score += 10;
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();
                    snake.body.Add(new Point(0, 0));
                }
                if (snake.IsCollisionWithObject(wall))
                {
                    Console.Write("Press any button.");
                    isAlive = false;
                }
                if (snake.IsCollisionWithItself())
                    isAlive = false;
                Draw();
                Thread.Sleep(100);
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
