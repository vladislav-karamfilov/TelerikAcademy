using System;

class QuadronacciRectangle
{
    static void Main()
    {
        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        long fourth = long.Parse(Console.ReadLine());
        byte rows = byte.Parse(Console.ReadLine());
        byte columns = byte.Parse(Console.ReadLine());
        int elements = rows * columns - 4;
        Console.Write(first + " " + second + " " + third + " " + fourth + " ");
        while (elements > 0)
        {
            long result = first + second + third + fourth;
            first = second;
            second = third;
            third = fourth;
            fourth = result;
            if (elements % columns == 0)
            {
                Console.WriteLine();
            }
            Console.Write(result + " ");
            elements--;
        }
    }
}
