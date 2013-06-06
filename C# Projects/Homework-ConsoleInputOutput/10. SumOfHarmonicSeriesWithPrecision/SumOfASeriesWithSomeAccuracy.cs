using System;

class SumOfASeriesWithSomeAccuracy
{
    static void Main()
    {
        string decorationLine = new String('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the sum of the series 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...\nwith accuracy of 0.001***");
        Console.Write(decorationLine);
        decimal accuracy = 0.001M;
        int denominator = 2;
        decimal sum = 1M;
        decimal tempSum = 0M;
        while (Math.Abs(sum - tempSum) >= accuracy)
        {
            if (denominator % 2 == 0)
            {
                tempSum = sum;
                sum += (decimal)1 / denominator;
                denominator++;
            }
            else
            {
                tempSum = sum;
                sum -= (decimal)1 / denominator;
                denominator++;
            }
        }
        Console.WriteLine("The sum of the series 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...\nwith accuracy of 0.001 is {0:0.000}.", sum);
    }
}
