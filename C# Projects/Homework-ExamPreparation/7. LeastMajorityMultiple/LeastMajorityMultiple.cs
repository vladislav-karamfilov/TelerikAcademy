using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        byte[] numbers = new byte[5];
        for (byte index = 0; index < 5; index++)
        {
            numbers[index] = byte.Parse(Console.ReadLine());
        }
        uint number = 1;
        while (true)
        {
            byte count = 0;
            if (number % numbers[0] == 0)
            {
                count++;
            }
            if (number % numbers[1] == 0)
            {
                count++;
            }
            if (number % numbers[2] == 0)
            {
                count++;
            }
            if (number % numbers[3] == 0)
            {
                count++;
            }
            if (number % numbers[4] == 0)
            {
                count++;
            }
            if (count >= 3)
            {
                Console.WriteLine(number);
                break;
            }
            number++;
        }
    }
}
