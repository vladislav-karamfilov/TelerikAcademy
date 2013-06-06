using System;
using System.Globalization;
using System.Threading;

class MostFrequentNumber
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the most frequent number in an array***");
        Console.Write(decorationLine);
        // Getting the length and filling the array
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        double[] numbers = new double[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter a real number: ");
            numbers[index] = double.Parse(Console.ReadLine().Replace(',', '.'));
        }
        Array.Sort(numbers); // Sorting the array so we can scan with only one loop
        int frequency = 1;
        int maxFrequency = 1;
        double mostFrequent = numbers[0];
        for (int index = 1; index < length; index++)
        {
            if (numbers[index] == numbers[index - 1])
            {
                frequency++;
                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                    mostFrequent = numbers[index];
                }
            }
            else
            {
                frequency = 1;
            }
        }
        Console.WriteLine("The most frequent number is: {0} -> {1} times.", mostFrequent, maxFrequency);
    }
}
