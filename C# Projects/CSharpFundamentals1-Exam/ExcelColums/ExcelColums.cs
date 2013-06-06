using System;

class ExcelColums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string concatenation = null;
        for (int i = 0; i < n; i++)
        {
            concatenation += Console.ReadLine();
        }
        ulong sum = 0;
        for (int i = 0; i < concatenation.Length; i++)
        {
            sum *= 26;
            sum += (ulong)(concatenation[i] - 'A' + 1);
        }
        Console.WriteLine(sum);
    }
}
