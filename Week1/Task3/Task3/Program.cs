using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаю массив
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            //Записываю значения в string 
            string[] arr = Console.ReadLine().Split();
            //Записываю массив из integer значений
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]);
            }
            //Вывожу на экран
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " " + a[i] + " ");
            }
            Console.Read();
        }
    }
}
