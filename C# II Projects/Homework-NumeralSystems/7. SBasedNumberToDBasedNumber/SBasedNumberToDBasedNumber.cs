using System;
using System.Text;

class SBasedNumberToDBasedNumber
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a number from S-based numeral system to D-based numeral \nsystem (2 <= s, d <= 16)***");
        Console.Write(decorationLine);
        Console.Write("Enter the base S for the numeral system from which you want to convert: ");
        byte sBase = byte.Parse(Console.ReadLine());
        Console.Write("Enter a number in {0}-based numeral system: ", sBase);
        string number = Console.ReadLine().ToUpper();
        Console.Write("Enter the base D for the numeral system to which you want to convert: ");
        byte dBase = byte.Parse(Console.ReadLine());
        if (dBase == sBase)
        {
            Console.WriteLine("The result is: " + number);
            return;
        }
        ulong decimalNumber = BaseSToDecimal(number, sBase);
        StringBuilder dBasedNumber = DecimalToBaseD(decimalNumber, dBase);
        Console.WriteLine("The result is: " + dBasedNumber);
    }

    static StringBuilder DecimalToBaseD(ulong decimalNumber, byte dBase)
    {
        StringBuilder dBasedNumber = new StringBuilder();
        char dBasedDigit = new char();
        while (decimalNumber != 0)
        {
            if (decimalNumber % dBase < 10)
            {
                dBasedDigit = (char)('0' + decimalNumber % dBase);
            }
            else
            {
                dBasedDigit = (char)('A' + decimalNumber % dBase - 10);
            }
            dBasedNumber.Append(dBasedDigit);
            decimalNumber /= dBase;
        }
        // Reversing the number to get the real value
        ReverseNumber(dBasedNumber);
        return dBasedNumber;
    }

    static void ReverseNumber(StringBuilder dBasedNumber)
    {
        for (int index = 0; index < dBasedNumber.Length / 2; index++)
        {
            if (dBasedNumber[index] != dBasedNumber[dBasedNumber.Length - index - 1])
            {
                char temp = dBasedNumber[index];
                dBasedNumber[index] = dBasedNumber[dBasedNumber.Length - index - 1];
                dBasedNumber[dBasedNumber.Length - index - 1] = temp;
            }
        }
    }

    static ulong BaseSToDecimal(string number, byte sBase)
    {
        ulong result = 0;
        byte decimalDigit = 0;
        for (int index = 0; index < number.Length; index++)
        {
            if (number[index] >= '0' && number[index] <= '9')
            {
                decimalDigit = (byte)(number[index] - '0');
            }
            else
            {
                decimalDigit = (byte)(10 + number[index] - 'A');
            }
            result += (ulong)(decimalDigit * Math.Pow(sBase, number.Length - index - 1));
        }
        return result;
    }
}
