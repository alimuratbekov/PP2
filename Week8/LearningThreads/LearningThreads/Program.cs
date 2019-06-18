using System;
using System.Threading;

namespace LearningThreads
{
    class Program
    {
        class MyThread
        {
            Thread thread;

            public MyThread(string name, int num)
            {
                thread = new Thread(this.func);
                thread.Name = name;
                thread.Start(num);
            }

            void func(object num)
            {
                for (int i=0;i<(int)num;i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " выводит " + i);
                    Thread.Sleep(2000);
                }
                Console.WriteLine("Поток " + Thread.CurrentThread.Name + " закончен ебать");
            }
        }
        static void Main(string[] args)
        {
            MyThread thread_1 = new MyThread("Жопа", 10);
            MyThread thread_2 = new MyThread("Пися", 4);
            Console.Read();
        }
    }
}
