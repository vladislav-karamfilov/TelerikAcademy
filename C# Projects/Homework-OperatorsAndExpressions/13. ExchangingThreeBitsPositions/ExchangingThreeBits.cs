using System;

class ExchangingThreeBits
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Exchanging bits 3, 4 and 5 with bits 24, 25 and 26\nof a given 32-bit unsigned integer***");
        Console.Write(decorationLine);
        Console.Write("Enter an unsigned integer: ");
        uint number = uint.Parse(Console.ReadLine());
        for (int bitPosition = 3; bitPosition < 6; bitPosition++)
        {
            uint mask1 = 1U << bitPosition;
            uint mask2 = 1U << (21 + bitPosition);
            if (((number & mask1) == 0) && ((number & mask2) != 0))
            {
                //Console.WriteLine(Convert.ToString(number, 2)); //-> initial value
                number &= ~mask2; //Changing the bit in (bitPosition + 21) into the bit in bitPosition
                //Console.WriteLine(Convert.ToString(number, 2)); //-> check
                number |= mask1; //Changing the bit in bitPosition into the bit in (bitPosition + 21)
               //Console.WriteLine(Convert.ToString(number, 2)); //-> check
            }
            else if (((number & mask1) != 0) && ((number & mask2) == 0))
            {
                //Console.WriteLine(Convert.ToString(number, 2)); //-> initial value
                number |= mask2;
                //Console.WriteLine(Convert.ToString(number, 2)); //-> check
                number &= ~mask1;
                //Console.WriteLine(Convert.ToString(number, 2)); //-> check
            }
        }
        Console.WriteLine("After exchanging bits 3, 4, 5 with bits 24, 25, 26 the new value is {0}.", number);
    }
}