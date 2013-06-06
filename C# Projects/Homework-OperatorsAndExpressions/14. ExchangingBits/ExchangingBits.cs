using System;

class ExchangingBits
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Exchanging as many as you want bits of an unsigned integer.\nKeep in mind it has 31 bits (counting from 0)!***");
        Console.Write(decorationLine);
        Console.Write("Enter an unsigned integer: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("Enter how many bits you want to exchange: ");
        byte numberOfBits = byte.Parse(Console.ReadLine());
        Console.Write("Enter from which position to take the first {0} bits (counting from 0): ", numberOfBits);
        byte bitPosition1 = byte.Parse(Console.ReadLine());
        Console.Write("Enter from which position to take the second {0} bits (counting from 0): ", numberOfBits);
        byte bitPosition2 = byte.Parse(Console.ReadLine());
        for (int bitPosition = bitPosition1; bitPosition < (bitPosition1 + numberOfBits); bitPosition++, bitPosition2++)
        {
            uint mask1 = 1U << bitPosition;
            uint mask2 = 1U << bitPosition2;
            if (((number & mask1) == 0) && ((number & mask2) != 0))
            {
                //Console.WriteLine(Convert.ToString(number, 2)); //-> initial value
                number &= ~mask2; //Changing the bit in (bitPosition + bitPosition2) into the bit in bitPosition
                //Console.WriteLine(Convert.ToString(number, 2)); //-> check
                number |= mask1; //Changing the bit in bitPosition into the bit in (bitPosition + bitPosition2)
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
        Console.WriteLine("After exchanging {0} bits from position {1} with {0} bits from position {2},\nthe new value is {3}.", 
            numberOfBits, bitPosition1, bitPosition2 - numberOfBits, number);
    }
}