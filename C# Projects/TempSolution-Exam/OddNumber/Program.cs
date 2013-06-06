using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<long, int> temp = new Dictionary<long, int>();
            for (int i = 0; i < n; i++)
            {
                long number = long.Parse(Console.ReadLine());
                if (temp.ContainsKey(number))
                {
                    temp[number]++;
                }
                else
                {
                    temp.Add(number, 1);
                }
            }
            foreach (var item in temp)
            {
                if (item.Value % 2 == 1)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
            }
        }
    }
}
