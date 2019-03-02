using System;
using System.Xml.Serialization;
using System.IO;

namespace Task1
{
    //создаём класс для вывода комплексных чисел по формуле a+bi
    public class Complex
    {
        public int real, img;
        public Complex() { }
        public void Print()
        {
            Console.WriteLine($"{real} + {img}i");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //объявляем переменную типа Complex
            Complex s = new Complex();
            //объявляем значения a (real) и b (imaginary)
            s.real = int.Parse(Console.ReadLine());
            s.img = int.Parse(Console.ReadLine());
            s.Print();
            //создаём файл .xml куда записываются значения s
            FileStream fs = new FileStream("Complex.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            //сериализуем значения s в файле fs
            xs.Serialize(fs, s);
            fs.Close();
            //считываем значения из раннее созданного файла .xml
            FileStream fs1 = new FileStream("Complex.xml", FileMode.Open, FileAccess.Read);
            //десериализуем все значения в новую переменную s1
            Complex s1 = xs.Deserialize(fs1) as Complex;
            s1.Print();
            fs1.Close();
            Console.ReadKey();
        }
    }
}
