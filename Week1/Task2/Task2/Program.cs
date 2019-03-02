using System;

namespace Task2
{
    public class Student
    {
        string name;
        string id;
        int year;
        public Student(string name, string id, int year)
        {
            this.name = name;
            this.id = id;
            this.year = year;
        }
        public void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine(id);
            Console.WriteLine(year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string id = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            Student st1 = new Student(name, id, ++year);
            st1.Print();
            Console.ReadLine();
        }
    }
}
