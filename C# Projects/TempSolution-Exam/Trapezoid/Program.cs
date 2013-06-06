using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            Console.Write(new string('.', n));
            Console.WriteLine(new string('*', n));
            for (int i = 1; i < n; i++)
            {
                Console.Write(new string('.', n - i));
                Console.Write("*");
                Console.Write(new string('.', n + i - 2));
                Console.Write("*");
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 2 * n));
        }
    }
}
