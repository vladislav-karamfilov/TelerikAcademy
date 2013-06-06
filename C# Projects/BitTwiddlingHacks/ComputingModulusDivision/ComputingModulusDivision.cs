using System;

class ComputingModulusDivision
{
    static void Main()
    {
        // Computing modulus division by 1 << s without a division operator
        int number = 1251262334;
        int s = 15;
        int divisor = 1 << s;
        int result = number & (divisor - 1); // Number % divisor
        Console.WriteLine(result);
        
        // Computing modulus division by (1 << s) - 1 without a division operator
        number = 512756965;
        s = 12;
        divisor = (1 << s) - 1;
        for (result = number; number > divisor; number = result)
        {
            for (result  = 0; number != 0; number >>= s)
            {
                result += number & divisor;
            }
        }
        result = result == divisor ? 0 : result;
        Console.WriteLine(result);
    }
}
