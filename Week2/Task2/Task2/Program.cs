using System;
using System.IO;
using System.Collections.Generic;
namespace Task2
{
    class Program
    {
        //функция для проверки простых чисел
        public static bool isprime(int n)
        {
            for (int i=2;i<=Math.Sqrt(n);i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            //считывает значения с файла
            StreamReader sr = new StreamReader("input.txt");
            String s = sr.ReadToEnd();
            String[] arr = s.Split();
            int[] a = new int[arr.Length];
            sr.Close();
            // пробегается по массиву из строк и переводит их в integer
            for (int i = 0; i < arr.Length; i++)
            {
                a[i] = int.Parse(arr[i]);
            }
            //пробегается по массиву, и выводит в файл простые числа
            StreamWriter sw = new StreamWriter("output.txt");
            for (int i=0;i<a.Length;i++)
            {
                if (isprime(a[i]) == true) sw.Write(a[i] + " ");
            }
            sw.Close();
        }
    }
}
