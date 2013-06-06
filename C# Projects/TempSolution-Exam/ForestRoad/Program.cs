using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestRoad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', n - 1 - i));
                Console.WriteLine();
            }
            for (int i = 1; i < n; i++)
            {
                Console.Write(new string('.', n - 1 - i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
        }
    }
}
