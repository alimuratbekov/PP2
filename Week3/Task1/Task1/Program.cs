using System;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public int cursor;
        public bool ok;
        public int sz;
        public FarManager()
        {
            cursor = 0;
            ok = true;
        }
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
        public void Start(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while(true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                show(path);
                consoleKey = Console.ReadKey();
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
            FarManager farmanager = new FarManager();
            farmanager.Start("/PP2/");
            Console.ReadKey();
        }
    }
}
