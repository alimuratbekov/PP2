using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace Shop
{
    public class Shop
    {
        public string username, choice;
        public Shop() { }
        public Shop(string username, string choice)
        {
            this.username = username;
            this.choice = choice;
        }

        public void Print()
        {
            Console.WriteLine(username + " " + choice);
        }
    }

    class serial
    {
        public serial() { }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter your name: ");
            string username = Console.ReadLine();
            string ch = "";

            List<string> Food = new List<string>();
            Food.Add("Milk");
            Food.Add("Bread");
            Food.Add("Cheese");
            Food.Add("Melon");
            Food.Add("Sugar");

            for (int i=0;i<Food.Count;i++)
            {
                Console.WriteLine(i + 1 + ". " + Food[i]);
            }

            Console.Write("Your choise is: ");
            int num = int.Parse(Console.ReadLine());
            for (int i=0;i<=Food.Count;i++)
            {
                if (i==num)
                {
                    ch = Food[i-1];
                }
            }
            Shop shop = new Shop(username, ch);

            
            FileStream fs1 = new FileStream("shop.xml", FileMode.Open, FileAccess.Read);
            Shop shop1 = xs.Deserialize(fs1) as Shop;
            shop1.Print();
            Console.ReadKey();
        }
    }
}
