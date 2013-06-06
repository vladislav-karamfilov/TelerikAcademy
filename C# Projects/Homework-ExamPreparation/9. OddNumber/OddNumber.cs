using System;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long number = new long();
        long oddNumber = new long();
        do
        {
            number = long.Parse(Console.ReadLine());
            oddNumber ^= number; // Using that the bits of the odd number won't become 
                                 // 0s because of repeating the same bits even times
            n--;
        }
        while (n > 0);
        Console.WriteLine(oddNumber);
    }
}
