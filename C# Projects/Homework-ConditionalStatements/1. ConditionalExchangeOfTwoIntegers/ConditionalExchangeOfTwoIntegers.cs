using System;

class ConditionalExchangeOfTwoIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Exchanging the values of two integers if the first one\nis greater than the second one***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer a: ");
        int firstInteger;
        if (!int.TryParse(Console.ReadLine(), out firstInteger))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        Console.Write("Enter an integer b: ");
        int secondInteger;
        if (!int.TryParse(Console.ReadLine(), out secondInteger))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        if (firstInteger > secondInteger)
        {
            int temp = firstInteger;
            firstInteger = secondInteger;
            secondInteger = temp;
            Console.WriteLine("After the exchange a = {0} and b = {1}.", firstInteger, secondInteger);
        }
        else
        {
            Console.WriteLine("There is no need to exchange the values because a <= b.");
        }
    }
}
