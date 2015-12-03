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
            ListExample(new IntegerList());
        }

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
