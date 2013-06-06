using System;

class TheBiggestOfThreeIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the biggest of three integers***");
        Console.Write(decorationLine);
        Console.Write("Enter first integer: ");
        int firstInteger;
        if (!int.TryParse(Console.ReadLine(), out firstInteger))
        {
            Console.WriteLine("Inalid input!");
            return;
        }
        Console.Write("Enter second integer: ");
        int secondInteger;
        if (!int.TryParse(Console.ReadLine(), out secondInteger))
        {
            Console.WriteLine("Inalid input!");
            return;
        }
        Console.Write("Enter third integer: ");
        int thirdInteger;
        if (!int.TryParse(Console.ReadLine(), out thirdInteger))
        {
            Console.WriteLine("Inalid input!");
            return;
        }
        if (firstInteger >= secondInteger)
        {
            if (firstInteger >= thirdInteger)
            {
                Console.WriteLine("The biggest of {0}, {1} and {2} is {0}.", firstInteger, secondInteger, thirdInteger);
            }
            else if (firstInteger <= thirdInteger)
            {
                Console.WriteLine("The biggest of {0}, {1} and {2} is {2}.", firstInteger, secondInteger, thirdInteger);
            }
        }
        else
        {
            if (secondInteger >= thirdInteger)
            {
                Console.WriteLine("The biggest of {0}, {1} and {2} is {1}.", firstInteger, secondInteger, thirdInteger);
            }
            else if (secondInteger <= thirdInteger)
            {
                Console.WriteLine("The biggest of {0}, {1} and {2} is {2}.", firstInteger, secondInteger, thirdInteger);
            }
        }
    }
}
