using System;
using System.Collections.Generic;

class CodeWithFibunacciSequence
{
    static void Main()
    {
        string code = Console.ReadLine();
        int first = 1;
        int second = 2;
        List<int> fibunacci = new List<int>();
        fibunacci.Add(first);
        fibunacci.Add(second);
        int temp = new int();
        for (int i = 0; i < code.Length; i++)
        {
            temp = first + second;
            fibunacci.Add(temp);
            first = second;
            second = temp;
            if (fibunacci.Contains(i) == false)
            {
                Console.Write(code[i]);
            }
        }
        Console.WriteLine();
    }
}
