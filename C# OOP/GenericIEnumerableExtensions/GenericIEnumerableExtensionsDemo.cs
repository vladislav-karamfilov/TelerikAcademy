using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericIEnumerableExtensions
{
    class GenericIEnumerableExtensionsDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Finding sum, product, minimal and maximal elements and average of all the");
            Console.WriteLine("elements of an enumeration that implements the interface IEnumerable<T>***");
            Console.Write(decorationLine);
            
            // Testing with integers
            IEnumerable<int> collectionOfIntegers = new List<int>() { 222, 15181, -125197, 12571, -152 };
            Console.WriteLine("Minimum: " + collectionOfIntegers.Min());
            Console.WriteLine("Maximum: " + collectionOfIntegers.Max());
            Console.WriteLine("Average: " + collectionOfIntegers.Average());
            Console.WriteLine("Product: " + collectionOfIntegers.Product());
            Console.WriteLine("Sum: " + collectionOfIntegers.Sum());

            Console.WriteLine();

            // Testing with doubles
            IEnumerable<double> collectionOfDoubles = new double[6] { -22.1, 251.2, -512, 22, -16, 0.1 };
            Console.WriteLine("Minimum: " + collectionOfDoubles.Min());
            Console.WriteLine("Maximum: " + collectionOfDoubles.Max());
            Console.WriteLine("Average: " + collectionOfDoubles.Average());
            Console.WriteLine("Product: " + collectionOfDoubles.Product());
            Console.WriteLine("Sum: " + collectionOfDoubles.Sum());
        }
    }
}
