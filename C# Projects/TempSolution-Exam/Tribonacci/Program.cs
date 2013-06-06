using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n1 = BigInteger.Parse(Console.ReadLine());
            BigInteger n2 = BigInteger.Parse(Console.ReadLine());
            BigInteger n3 = BigInteger.Parse(Console.ReadLine());
            ushort n = ushort.Parse(Console.ReadLine());
            BigInteger result = n3;
            for (int i = 4; i <= n; i++)
            {
                result = Tribonacci(n1, n2, n3);
                n1 = n2;
                n2 = n3;
                n3 = result;
            }
            Console.WriteLine(result);
        }
        static BigInteger Tribonacci(BigInteger n1, BigInteger n2, BigInteger n3)
        {
            return n1 + n2 + n3;
        }
    }
}
