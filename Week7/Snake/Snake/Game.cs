using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    class Game
    {
        public bool isAlive;
        public string username;
        public int score = 0;
        public int speed = 80;

        List<GameObject> g_objects;

        public Snake snake;
        public Food food;
        public Wall wall;

        public Game()
        {
            g_objects = new List<GameObject>();

            isAlive = true;

            snake = new Snake(5, 3, "o", ConsoleColor.Blue);

            food = new Food(0, 0, "O", ConsoleColor.Green);
            food.Generate();

            wall = new Wall("+", ConsoleColor.Gray);
            wall.Walls();

            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();

            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);

            Console.CursorVisible = false;

            Console.SetWindowSize(40, 20);
        }
        public void Start()
        {
            Console.WriteLine("Do you want to resume game?");
            string ans1 = Console.ReadLine();
            if (ans1 == "yes")
            {

            }

            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Press any button to start.");

            ConsoleKeyInfo consoleKey = Console.ReadKey();

            Thread thread = new Thread(MoveSnake);
            thread.Start();

            while (isAlive && consoleKey.Key != ConsoleKey.Escape)
            {
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Spacebar)
                {
                    isAlive = false;
                }
                snake.ChangeDirection(consoleKey);
            }
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("GAME OVER!");
            Console.SetCursorPosition(4, 9);
            Console.WriteLine("Do you want to save progress?");
            string ans = Console.ReadLine();
            if (ans == "yes") Save();
            else if (ans == "no")
            {
                Console.WriteLine(username + ", your score is " + score);
            }
            //Console.ReadKey();
            //Save();

            /*Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(15, 6);
            Console.Write("GAME OVER!");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine(username + ", your score is: " + score);
            */

            Console.ReadKey();
        }

        public void MoveSnake()
        {
            while (isAlive)
            {
                snake.Move();
                Draw();
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
                //Draw();
                if (snake.body.Count == 3)
                {
                    speed = 50;
                }
                else if (snake.body.Count == 6)
                {
                    speed = 30;
                }
                Thread.Sleep(speed);
            }
        }

        public void Draw()
        {
            if (snake.body.Count == 1)
            {
                Console.Clear();
            }
            foreach (GameObject g in g_objects)
            {
                g.Draw();
            }
        }

        public void Save()
        {
            Saved saved;
            saved = new Saved(username, score, snake.body);
            FileStream fs = new FileStream("Saved.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Saved));
            xs.Serialize(fs, saved);
            fs.Close();
        }

        public void Resume()
        {
            FileStream fs1 = new FileStream("Saved.xml", FileMode.Open, FileAccess.Read);

        }
    }
}
