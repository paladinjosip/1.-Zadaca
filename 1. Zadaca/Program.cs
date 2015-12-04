using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Zadaca
{
    class Program
    {
        static void Main(string[] args)
        {
          //  ListExample(new IntegerList());   //1. zadatak

            //2. i 4. zadatak
            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");

            foreach (string value in stringList) {
                Console.WriteLine(value);
            }
            Console.WriteLine(stringList.Count);
            Console.WriteLine(stringList.Contains("Hello"));
            Console.WriteLine(stringList.IndexOf("Hello"));
            Console.WriteLine(stringList.GetElement(1));

            IGenericList<double> doubleList = new GenericList<double>();
            doubleList.Add(0.2);
            doubleList.Add(0.7);
         
            Console.Read();
        }

        //Metoda za 1. zadatak
        private static void ListExample(IIntegerList listOfInteger)
        {
            listOfInteger.Add(1);
            listOfInteger.Add(2);
            listOfInteger.Add(3);
            listOfInteger.Add(4);
            listOfInteger.Add(5);
            
            
            listOfInteger.RemoveAt(0);
            listOfInteger.Remove(5);

            Console.WriteLine(listOfInteger.Count);

            Console.WriteLine(listOfInteger.Remove(100));
            Console.WriteLine(listOfInteger.RemoveAt(5));
            listOfInteger.Clear();
            Console.WriteLine(listOfInteger.Count);
            Console.ReadLine();
        }

    }
}
