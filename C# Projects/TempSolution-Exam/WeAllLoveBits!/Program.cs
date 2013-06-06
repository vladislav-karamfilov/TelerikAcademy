using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAllLoveBits_
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort n = ushort.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                uint p = uint.Parse(Console.ReadLine());
                Console.WriteLine(ReverseBits(p, CountBits(p)));
            }
        }

        static byte CountBits(uint p)
        {
            byte bits = 0;
            while (p != 0)
            {
                bits++;
                p >>= 1;
            }
            return bits;
        }

        static uint ReverseBits(uint p, byte bits)
        {
            uint reversed = 0;
            byte i = 0;
            bool flag = false;
            while (p != 0)
            {
                if ((p & (1 << (bits - 1))) != 0)
                {
                    reversed += (uint)Math.Pow(2, i);
                    flag = true;
                }
                if (flag)
                {
                    i++;
                }
                p <<= 1;
            }
            return reversed;
        }
    }
}
