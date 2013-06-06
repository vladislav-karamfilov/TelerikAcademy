using System;
using System.Text;

class TripleRotationOfDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        int lastDigitIndex = number.Length - 1;
        string temp = null;
        for (int rotation = 0; rotation < 3; rotation++)
        {
            temp = number[lastDigitIndex].ToString();
            number = number.Remove(lastDigitIndex);
            if (temp != "0")
            {
                temp += number;
            }
            else
            {
                lastDigitIndex--;
                continue;
            }
            number = temp;
        }
        Console.WriteLine(number);
    }
}