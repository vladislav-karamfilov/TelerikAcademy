using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoscalesTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int n = int.Parse(Console.ReadLine()); // Odd number
            char copyright = '\u00A9';
            int spacesBefore = n - 1;
            int spacesBetween = 1;
            Console.Write(new string(' ', spacesBefore)); // First line spaces
            Console.WriteLine(copyright); // First line border
            for (int i = 0; i < n - 2; i++)
            {
                spacesBefore--;
                Console.Write(new string(' ', spacesBefore));
                Console.Write(copyright);
                Console.Write(new string(' ', spacesBetween));
                Console.Write(copyright);
                Console.WriteLine();
                spacesBetween += 2;
            }
            for (int i = 0; i < 2 * n; i++) // Last line
            {
                if (i % 2 == 0)
                {
                    Console.Write(copyright);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

//n = 5 
//    c      интервали преди = 4; интервали между = 0         
//   c c     интервали преди = 3; интервали между = 1
//  c   c    интервали преди = 2; интервали между = 3
// c     c   интервали преди = 1; интервали между = 5
//c c c c c

//n = 3
//  c
// c c
//c c c  

//n = 7
//      c
//     c c
//    c   c
//   c     c
//  c       c
// c         c
//c c c c c c c
