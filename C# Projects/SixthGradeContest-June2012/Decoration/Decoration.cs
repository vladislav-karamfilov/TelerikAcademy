using System;

/*
 * Algorithm:
 * Firstly this algorithm can be viewed as knapsack problem where individual
 * array elements are the weights and half the sum as total weight of the knapsack.
 * 1.take a solution array as boolean array sol[] of size sum/2+1
 * 2. For each array element,traverse the array and set sol [j] to be true if sol [j - value of array] is true
 * 3.Let halfsumcloser be the closest reachable number to half the sum and partition are sum-halfsumcloser and halfsumcloser.
 * 4.start from halfsum and decrease halfsumcloser once everytime until you find that sol[halfsumcloser] is true
 */

class Decoration
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        int[] weights = new int[n];
        int sum = 0;
        for (byte i = 0; i < n; i++)
        {
            weights[i] = int.Parse(input[i]);
            sum += weights[i];
        }
        bool[] solution = new bool[sum / 2 + 1];
        solution[0] = true;
        foreach (int weight in weights)
        {
            for (int j = sum / 2; j >= weight; j--)
            {
                if (solution[j - weight] == true)
                {
                    solution[j] = true;
                }
            }
        }
        int halfSum = sum / 2;
        while (solution[halfSum] == false)
        {
            halfSum--;
        }
        Console.WriteLine(sum - halfSum - halfSum);
    }
}
