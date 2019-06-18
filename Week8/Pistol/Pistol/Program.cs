using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace Pistol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread bullet = new Thread(Bullet);
            Thread gun = new Thread(Pistol);

            gun.Start();

            ConsoleKeyInfo consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Enter)
            {
                bullet.Start();
            }
        }

        static void Bullet()
        {
            int x=30;
            while(x!=Console.WindowWidth)
            {
                Console.Clear();
                Console.SetCursorPosition(x, 5);
                Console.Write('o');
                x++;
                Thread.Sleep(50);
            }
            Environment.Exit(0);
        }

        static void PistolDraw()
        {
            StreamReader sr = new StreamReader("pistol.txt");
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j]=='*')
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('*');
                    }
                }
            }
        }
        static void Pistol()
        {
            while (true)
            {
                PistolDraw();
                Thread.Sleep(0);
            }
        }

    }
}
