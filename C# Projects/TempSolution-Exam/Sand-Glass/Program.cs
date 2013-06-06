using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sand_Glass
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            for (byte i = 0; i < n / 2 + 1; i++)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', n - 2 * i));
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
            for (byte i = 0; i < n / 2; i++)
            {
                Console.Write(new string('.', n / 2 - i - 1));
                Console.Write(new string('*', 2 * i + 3));
                Console.Write(new string('.', n / 2 - i - 1));
                Console.WriteLine();
            }
        }
    }
}
