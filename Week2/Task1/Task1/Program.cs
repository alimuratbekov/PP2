using System;
using System.IO;

namespace Task1
{
    class Program
    {
        //Функция для проверки на палиндром
        public static bool ispalin(string s)
        {
            for (int i = 0, j=s.Length-1; i <= j; i++, j--)
            {
                if (s[i] != s[j]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            //считывает значения с файла
            StreamReader sr = new StreamReader("input.txt");
            String s = sr.ReadToEnd();
            //проверяет функцией и выводит ответ
            if (ispalin(s) == true)
            {
                Console.WriteLine("Yes");
            } 
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();
        }
    }
}
