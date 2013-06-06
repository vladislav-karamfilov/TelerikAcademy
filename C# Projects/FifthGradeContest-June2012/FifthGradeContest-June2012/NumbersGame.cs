using System;
using System.Collections.Generic;
// Need improvement => 50/100...
class NumbersGame
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split(' ');
        int n = int.Parse(input1[0]);
        int k = int.Parse(input1[1]);
        string[] input2 = Console.ReadLine().Split(' ');
        int[] numbers = new int[n];
        int answer = 0;
        List<int> winners = new List<int>();
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(input2[i]);
            int divisor = 2;
            int count = 0;
            do
            {
                if (k % divisor == 0 && numbers[i] % divisor == 0)
                {
                    count++;
                }
                divisor++;
            } while (divisor <= k);
            if (k % numbers[i] == 0)
            {
                count++;
            }
            if (count > answer)
            {
                answer = count;
                winners.Clear();
            }
            if (count == answer)
            {
                winners.Add(i + 1);
            }
        }
        if (answer == 0)
        {
            Console.WriteLine("No winners");
        }
        else
        {
            Console.WriteLine(answer);
            foreach (int winner in winners)
            {
                Console.Write(winner + " ");
            }
            Console.WriteLine();
        }
    }
}
