using System;

class AstrologicalDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        ushort sumOfDigits = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '.' || number[i] == '-')
            {
                continue;
            }
            sumOfDigits += (ushort)(number[i] - '0');
        }
        while (sumOfDigits > 9)
        {
            ushort temp = sumOfDigits;
            sumOfDigits = 0;
            do
            {
                sumOfDigits += (ushort)(temp % 10);
                temp /= 10;
            } while (temp != 0);
        }
        Console.WriteLine(sumOfDigits);
    }
}
