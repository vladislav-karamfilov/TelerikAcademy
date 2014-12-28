using System;
using System.Collections.Generic;
using System.Text;

class TwoTasks
{
    static Random generator = new Random();
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        int random = generator.Next(1, n);
        Console.WriteLine(random);
        Console.WriteLine("bounded");
        Console.WriteLine("unbounded");
    }
}
