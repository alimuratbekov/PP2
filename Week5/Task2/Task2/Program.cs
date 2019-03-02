using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    //создаём класс, который переводит оценку из числового значения в буквенное
    public class Mark
    {
        public int points;
        public Mark() { }
        public Mark(int p)
        {
            points = p;
        }
        public void GetAssesment()
        {
            if (points<50)
            {
                Console.WriteLine("F");
            }
            else if (points<54)
            {
                Console.WriteLine("D");
            }
            else if (points < 60)
            {
                Console.WriteLine("D+");
            }
            else if (points < 65)
            {
                Console.WriteLine("C-");
            }
            else if (points < 70)
            {
                Console.WriteLine("C");
            }
            else if (points < 75)
            {
                Console.WriteLine("C+");
            }
            else if (points < 80)
            {
                Console.WriteLine("B-");
            }
            else if (points < 85)
            {
                Console.WriteLine("B");
            }
            else if (points < 90)
            {
                Console.WriteLine("B+");
            }
            else if (points < 95)
            {
                Console.WriteLine("A-");
            }
            else if (points <= 100)
            {
                Console.WriteLine("A");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //создаём list, куда записываем различные оценки
            List<Mark> s = new List<Mark>();
            for (int i=0;i<3;i++)
            {
                int n = int.Parse(Console.ReadLine());
                s.Add(new Mark() { points = n });
            }
            //переводим все оценки в буквенный вид и выводим
            foreach(var v in s)
            {
                v.GetAssesment();
            }
            //создаём файл .xml, куда записываем все значения из раннее созданного list
            FileStream fs = new FileStream("List.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            //сериализуем все значения s в fs
            xs.Serialize(fs, s);
            fs.Close();
            //считываем все значения из ранне созданного .xml файла 
            FileStream fs1 = new FileStream("List.xml", FileMode.Open, FileAccess.Read);
            //десериализуем и снова выводим оценки в буквенном виде
            List<Mark> s1 = xs.Deserialize(fs1) as List<Mark>;
            foreach(var v in s1)
            {
                v.GetAssesment();
            }
            fs1.Close();
            Console.ReadKey();
        }
    }
}
