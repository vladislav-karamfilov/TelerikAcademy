using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDown
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] numbers = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                numbers[i] = byte.Parse(Console.ReadLine());
            }
            for (int j = 0; j < 7; j++)
            {
                for (int i = 7; i > 0; i--)
                {
                    byte temp = numbers[i];
                    numbers[i] |= numbers[i - 1];
                    numbers[i - 1] &= temp;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
