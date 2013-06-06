using System;

class ExchangingValuesOfTwoIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring two integers and assigning them with 5 and 10.\nThen exchanging their values and re-exchanging the values***");
        Console.Write(decorationLine);
        int firstInteger = 5;
        int secondInteger = 10;
        Console.WriteLine("The values before the exchange: {0} and {1}.", firstInteger, secondInteger);
        // Exchanging the values
        firstInteger = firstInteger + secondInteger;
        secondInteger = firstInteger - secondInteger;
        firstInteger = firstInteger - secondInteger;
        Console.WriteLine("The values after the exchange: {0} and {1}.", firstInteger, secondInteger);
        // Second way to exchage the values. This will re-exchange the values
        int temp = 0;
        temp = firstInteger;
        firstInteger = secondInteger;
        secondInteger = temp;
        Console.WriteLine("The values after re-exchanging: {0} and {1}.", firstInteger, secondInteger);
    }
}
