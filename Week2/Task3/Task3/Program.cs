using System;
using System.IO;

namespace Task3
{
    class Program
    {
        //Выводит пробелы перед файлами в зависимости от глубины
        public static void PrintSpaces(int level)
        {
            for (int i=0;i<level;i++)
            {
                Console.Write("   ");
            }
        }
        //Функция, которая показывает содержимое папок в указанной директории
        public static void show(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                show(d, level + 1);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("/Users/aliko/desktop/MINDKILLERS");
            show(dir, 0);
            Console.ReadKey();
        }
    }
}
