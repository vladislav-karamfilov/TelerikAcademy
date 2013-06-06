using System;

class ThirdDigitRightToLeft
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if integer's third digit right-to-left is 7***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int intNumber = int.Parse(Console.ReadLine());
        int tempInteger = intNumber / 100;
        bool checkDigit = ((Math.Abs(tempInteger % 10)) == 7);
        if (checkDigit == true)
        {
            Console.WriteLine("Third digit right-to-left of {0} is 7.", intNumber);
        }
        else
        {
            Console.WriteLine("Third digit right-to-left of {0} is not 7. It is {1}.", intNumber, Math.Abs(tempInteger % 10));
        }
    }
}