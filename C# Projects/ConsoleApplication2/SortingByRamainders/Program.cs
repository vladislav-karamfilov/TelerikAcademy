using System;
// Needs optimization
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        uint n = uint.Parse(input[0]);
        uint x = uint.Parse(input[1]);
        uint[] numbers = new uint[n];
        string[] numbersString = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            numbers[i] = uint.Parse(numbersString[i]);
        }
        Array.Sort(numbers);
        uint[] sorted = new uint[n];
        uint index1 = 0;
        for (int remainder = 0; remainder < x; remainder++)
        {
            for (int index = 0; index < n; index++)
            {
                if (numbers[index] % x == remainder)
                {
                    sorted[index1] = numbers[index];
                    index1++;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(sorted[i] + " ");
        }
        Console.WriteLine();
    }
}