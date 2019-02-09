using System;
using System.IO;

namespace Task1
{
    class Program
    {
        //01234
        //ababa
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
            StreamReader sr = new StreamReader("input.txt");
            String s = sr.ReadToEnd();
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
