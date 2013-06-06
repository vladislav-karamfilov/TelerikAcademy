using System;

class TribonacciTriangle
{
    static void Main()
    {
        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        byte lines = byte.Parse(Console.ReadLine());
        Console.WriteLine(first);
        Console.WriteLine(second + " " + third);
        long result = 0L;
        for (byte line = 3; line <= lines; line++)
        {
            int elements = line;
            while (elements > 0) // Counting the numbers on a line
            {
                result = first + second + third;
                first = second;
                second = third;
                third = result;
                Console.Write(result + " ");
                elements--;
            }
            Console.WriteLine();
        }
    }
}
