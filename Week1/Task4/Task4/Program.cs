using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввожжу количество строк/столбцов треугольника
            int n = int.Parse(Console.ReadLine());
            for (int i=1;i<=n;i++)
            {
                //Выводит количество звездочек, равное номеру строки
                for (int j=1;j<=i;j++)
                {
                    Console.Write("[*]");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
