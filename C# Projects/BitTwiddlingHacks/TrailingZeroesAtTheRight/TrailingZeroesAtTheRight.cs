using System;

class TrailingZeroesAtTheRight
{
    static void Main()
    {
        uint number = 568;
        byte counter = 0;
        if (number != 0)
        {
            number = (number ^ (number - 1)) >> 1; // Set number's trailing 0s to 1s and zero rest
            while (number != 0)
            {
                number >>= 1;
                counter++;
            }
        }
        else
        {
            counter = sizeof(uint) * 8;
        }
        Console.WriteLine(counter);
    }
}
