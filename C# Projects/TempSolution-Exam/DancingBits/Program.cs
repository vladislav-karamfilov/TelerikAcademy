using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string concatenation = null;
            for (int i = 0; i < n; i++)
            {
                concatenation += Convert.ToString(int.Parse(Console.ReadLine()), 2);
            }
            int count = 1;
            int answer = 0;
            for (int i = 0; i < concatenation.Length - 1; i++)
            {
                if (concatenation[i] == concatenation[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count == k)
                    {
                        answer++;
                    }
                    count = 1;
                }
            }
            if (count == k)
            {
                answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
