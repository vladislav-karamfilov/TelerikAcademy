using System;
using System.Collections.Generic;

class SimilarArrays
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        ushort[] array1 = new ushort[n];
        string[] inputArray1 = Console.ReadLine().Split(' ');
        for (ushort i = 0; i < n; i++)
        {
            array1[i] = ushort.Parse(inputArray1[i]);
        }
        ushort m = ushort.Parse(Console.ReadLine());
        ushort[] array2 = new ushort[m];
        string[] inputArray2 = Console.ReadLine().Split(' ');
        for (ushort i = 0; i < m; i++)
        {
            array2[i] = ushort.Parse(inputArray2[i]);
        }
        List<uint> unique1 = new List<uint>();
        foreach (var element in array1)
        {
            if (unique1.Contains(element) == false)
            {
                unique1.Add(element);
            }
        }
        List<uint> unique2 = new List<uint>();
        foreach (var element in array2)
        {
            if (unique2.Contains(element) == false)
            {
                unique2.Add(element);
            }
        }
        unique1.Sort();
        unique2.Sort();
        bool flag = false;
        foreach (var element in unique1)
        {
            if (unique2.Contains(element) == false)
            {
                flag = true;
                Console.Write(element + " ");
            }
        }
        if (flag == false)
        {
            Console.WriteLine(unique2.Count);
        }
        else
        {
            Console.WriteLine();
        }
    }
}
