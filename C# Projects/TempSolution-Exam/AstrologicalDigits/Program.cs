using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrologicalDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int sum;
            do
            {
                sum = 0;
                foreach (char symbol in n)
                {
                    if (symbol == '.' || symbol == '0' || symbol == '-')
                    {
                        continue;
                    }
                    sum += symbol - '0';
                }
                n = sum.ToString();
            } while (sum > 9);
            Console.WriteLine(sum);
        }
    }
}
