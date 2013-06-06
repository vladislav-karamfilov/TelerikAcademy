using System;
using System.Linq;

namespace DivisibleByThreeAndSevenNumbers
{
    class DivisibleByThreeAndSevenNumbers
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all the numbers from array that are divisible by 3 and 7***");
            Console.Write(decorationLine);

            // User defined input
            Console.Write("Enter how many elements the array has: ");
            int length = int.Parse(Console.ReadLine());
            int[] numbers = new int[length];
            for (int index = 0; index < length; index++)
            {
                Console.Write("Enter element {0}: ", index + 1);
                numbers[index] = int.Parse(Console.ReadLine());
            }

            // Using extension method + lambda expression
            // var divisibleByThreeAndSeven = numbers.Where(number => number % 3 == 0 && number % 7 == 0);

            // Using LINQ query
            var divisibleByThreeAndSeven =
                from number in numbers
                where number % 3 == 0 && number % 7 == 0
                select number;

            // Output
            Console.WriteLine("All numbers that are divisible by 3 and 7 are: ");
            foreach (var number in divisibleByThreeAndSeven)
            {
                Console.WriteLine(number);
            }
        }
    }
}
