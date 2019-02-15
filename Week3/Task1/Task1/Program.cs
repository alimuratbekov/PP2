using System;
using System.IO;

namespace Task1
{
    //создаю класс для farmanager
    class FarManager
    {
        //переменные для работы с курсором, скрытыми файлами
        public int cursor;
        public bool ok;
        public int sz;
        //конструктоп с заданными переменными
        public FarManager()
        {
            cursor = 0;
            ok = true;
        }
        //функции для перемещения курсора
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz-1;
        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
                cursor = 0;
        }
        // функция для окрашивания курсора, папок и файлов
        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        //функция для вывода содержимого директории на экран
        public void show(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = di.GetFileSystemInfos();
            sz = fileSystemInfos.Length;
            int index = 0;
            foreach (FileSystemInfo fs in fileSystemInfos)
            {
                if (ok && fs.Name.StartsWith("."))
                {
                    sz--;
                    continue;
                }
                Color(fs, index);
                Console.WriteLine(index+1 + ". " + fs.Name);
                index++;
            }
        }
        // функция для запуска farmanager
        public void Start(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileSystemInfo fs = null;
            //бесконечный цикл: ожидает нажатия какой нибудь кнопки
            while(true)
            {
                // выводит на экран содержимое
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                show(path);
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                // привязка определенных функций к кнопкам
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                    ok = true;
                if (consoleKey.Key == ConsoleKey.RightArrow)
                    ok = false;
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    di = di.Parent;
                    path = di.FullName;
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    int k = 0;
                    for (int i=0;i<di.GetFileSystemInfos().Length;i++)
                    {
                        if (ok && di.GetFileSystemInfos()[i].Name.StartsWith(".")) {
                            continue;
                        }
                        if (cursor==k)
                        {
                            fs = di.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        di = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // объявление класса и вызов функции
            FarManager farmanager = new FarManager();
            farmanager.Start("/PP2/");
        }
    }
}
