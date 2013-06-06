using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirTree
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            for (byte i = 0; i < n - 1; i++)
            {
                Console.Write(new string('.', n - i - 2));
                Console.Write(new string('*', 2 * i + 1));
                Console.Write(new string('.', n - i - 2));
                Console.WriteLine();
            }
            Console.Write(new string('.', n - 2));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', n - 2));
        }
    }
}
