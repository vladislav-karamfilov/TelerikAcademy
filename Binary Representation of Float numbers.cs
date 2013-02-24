using System;
using System.Text;

class BinaryRepresentationOfFloat
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the binary representation of signed 32-bit floating-point number***");
        Console.Write(decorationLine);
        Console.Write("Enter a floating-point number: ");
        float number = float.Parse(Console.ReadLine());
        string binary = FloatToBinary(number);
        Console.WriteLine("The binary representation of {0} is: {1}.", number, binary);
    }

    static string FloatToBinary(float number)
    {
        string binary = null;
        string sign = "0"; // Assuming the number is non-negative
        if (number < 0)
        {
            sign = "1";
            number = Math.Abs(number);
        }
        // Special case: the number is 0
        if (number == 0)
        {
            binary = ("0" + " " + "0".PadRight(8, '0') + " " + "0".PadRight(23, '0'));
            return binary;
        }
        string intPartBinary = DecimalToBinary((int)number);
        string fractionPartBinary = FractionToBinary(number - (int)number);
        StringBuilder temp = new StringBuilder(intPartBinary + fractionPartBinary);
        int exponent = 127 + NormalizeMantissa(temp, intPartBinary.Length); // Normalizing the mantissa we get the real exponent
        string exponentInBinary = DecimalToBinary(exponent).PadLeft(8, '0'); // Adding zeroes so the exponent is an 8-digit binary number
        binary = (sign + " " + exponentInBinary + " " + temp).PadRight(34, '0');
        return binary;
    }

    static int NormalizeMantissa(StringBuilder temp, int dotPositionInTemp)
    {
        if (temp[0] == '1' && temp[1] == '.') // The mantissa is normalized (e.g. 1.10010101)
        {
            return 0;
        }
        else if (temp[0] == '0' && temp[1] == '.') // Shifting to the left is needed to normalize the mantissa (e.g. 0.000110101)
        {
            int result = 0;
            while (temp[0] != '1')
            {
                char swap = temp[1];
                temp[1] = temp[2];
                temp[2] = swap;
                temp.Remove(0, 1);
                result--;
            }
            temp.Remove(0, 2); // Removing the "1." from the mantissa
            return result;
        }
        else // Shifting to the right is needed to normalize the mantissa (e.g. 11101.001101)
        {
            int result = 0;
            while (temp[1] != '.')
            {
                char swap = temp[dotPositionInTemp];
                temp[dotPositionInTemp] = temp[dotPositionInTemp - 1];
                temp[dotPositionInTemp - 1] = swap;
                result++;
                dotPositionInTemp--;
            }
            temp.Remove(0, 2); // Removing the "1." from the mantissa
            return result;
        }
    }

    static string FractionToBinary(float fraction)
    {
        string result = ".";
        while (fraction != 0)
        {
            fraction *= 2;
            char intPart = (char)((int)fraction + '0');
            result += intPart;
            fraction -= (int)fraction;
        }
        return result;
    }

    static string DecimalToBinary(int number)
    {
        string result = null;
        if (number == 0)
        {
            return "0";
        }
        while (number != 0)
        {
            result += (char)(number % 2 + '0');
            number >>= 1;
        }
        char[] temp = result.ToCharArray();
        Array.Reverse(temp);
        result = new string(temp);
        return result;
    }
}
