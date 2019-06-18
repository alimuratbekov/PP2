using System;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            for (int i=0;i<3;i++)
            {
                threads[i] = new Thread(print);
                threads[i].Name = Console.ReadLine();
            }
            for (int i=0;i<3;i++)
            {
                threads[i].Start();
            }
        }
        static void print()
        {
            for (int i=0;i<3;i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        } 
    }
}
