using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Объявляю переменную, которой присвоен путь до файла
            string path = "/Users/aliko/desktop/MINDKILLERS/File.txt";
            string path1 = "/Users/aliko/desktop";
            FileInfo fi = new FileInfo(path);
            //копирую из path в path1
            fi.CopyTo(path1 + "/Copy.txt",true);
            //удаляю в path
            fi.Delete();
        }
    }
}
