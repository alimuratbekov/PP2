using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Объявляю переменные, которыми присвоены пути (откуда и куда)
            string path = "/Users/aliko/desktop/MINDKILLERS";
            string path1 = "/Users/aliko/desktop/file.txt";
            path = Path.Combine(path, "file.txt");
            FileStream fi = File.Create(@"/Users/aliko/desktop/MINDKILLERS/file.txt");
            fi.Close();
            //копирую из path в path1
            File.Copy(path,path1,true);
            //удаляю в path
            File.Delete(path);
        }
    }
}
