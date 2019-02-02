using System;

namespace Task2
{
    public class Student
    {
        public string name = "Ali";
        public string id = "18BD110214";
        public int year = 1;
    }
    class Program
    {
        static void Main(string[] args)
        {
                Student st1 = new Student();
                Console.WriteLine(st1.name + " " + st1.id + " " + ++st1.year);
                Console.ReadLine();
        }
    }
}
