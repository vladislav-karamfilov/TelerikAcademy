using System;
using System.Collections.Generic;

class Chocolates
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split(' ');
        int n = int.Parse(input1[0]);
        int k = int.Parse(input1[1]);
        string[] input2 = Console.ReadLine().Split(' ');
        int minLength = int.MaxValue;
        for (int i = 0; i < n - k; i++)
        {
            int length = 1;
            int count = 1;
            List<string> temp = new List<string>();
            temp.Add(input2[i]);
            for (int j = i + 1; j < n; j++)
            {
                length++;
                if (length >= minLength)
                {
                    continue;
                }
                if (temp.Contains(input2[j]) == false)
                {
                    count++;
                    if (count == k)
                    {
                        if (minLength > length)
                        {
                            minLength = length;
                        }
                        break;
                    }
                    temp.Add(input2[j]);
                }
            }
        }
        Console.WriteLine(minLength);
    }
}