using System;
using System.IO;

namespace Task1__upd_
{
    class FarManager
    {
        //объявляю переменные необходимые для перемещения курсора
        public int cursor;
        public int sz;
        // переменная для просмотра/скрытия скрытых файлов
        public bool ok;
        // конструктор содержащий эти переменные
        public FarManager()
        {
            ok = true;
            cursor = 0;
        }
        //курсор идет вверх
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz - 1;
        } 
        //курсор вниз
        public void Down()
        {
            cursor++;
            if (cursor == sz)
                cursor = 0;
        }
        //функция, которая окрашивает курсор/папки/файлы
        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        //функция, которая выводит на экран файлы/папки в указанной директории
        public void Show(string path)
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
                Console.WriteLine(fs.Name);
                index++;
            }
        }
        //функция, в которой происходит весь процесс работы с FarManager
        public void Start(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                //перед тем как выводить на экран перемещенный курсор, очищает его
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                //привязка к кнопкам определенных функций
                consoleKey = Console.ReadKey();
                //escape = переход на директорию выше
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    di = di.Parent;
                    path = di.FullName;
                }
                // курсор - вверх и вниз
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                // показ и скрытие скрытых папок
                if (consoleKey.Key == ConsoleKey.RightArrow)
                    ok = false;
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                    ok = true;
                // enter = вхождение в папку
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    int k = 0;
                    for (int i=0;i<di.GetFileSystemInfos().Length; i++)
                    {
                        if (ok && di.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        if (cursor == k)
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
            //объявление класса и вызов функции
            FarManager farManager = new FarManager();
            farManager.Start("/Users/aliko/desktop/MINDKILLERS");
        }
    }
}
