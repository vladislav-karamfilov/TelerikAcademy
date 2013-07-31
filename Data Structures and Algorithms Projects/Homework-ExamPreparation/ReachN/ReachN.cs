using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class ReachN
{
    static void Main()
    {
        for (int i = 0; i < 4; i++)
        {
            long currentNumber = long.Parse(Console.ReadLine());
            Console.WriteLine(GetMinOperationsCount(currentNumber));
        }
    }

    static long GetMinOperationsCount(long targetNumber)
    {
        if (targetNumber == 1)
        {
            return 0;
        }

        OrderedBag<Tuple<long, long>> numbers = new OrderedBag<Tuple<long, long>>(new TupleComparer());
        numbers.Add(new Tuple<long, long>(targetNumber, 0));
        while (numbers.Count > 0)
        {
            Tuple<long, long> current = numbers.RemoveFirst();
            if (current.Item1 == 1)
            {
                return current.Item2 - 1;
            }

            for (int power = 2; power <= 60; power++)
            {
                double powerBase = Math.Pow(current.Item1, 1.0 / power);
                if (powerBase < 1)
                {
                    break;
                }

                long next = (long)Math.Round(powerBase);
                long numberOfSteps = Math.Abs(GetPowerSteps(next, power) - current.Item1);
                numbers.Add(new Tuple<long, long>(next, numberOfSteps + current.Item2 + 1));
            }
        }

        throw new InvalidOperationException("Cannot find the min operations count!");
    }

    static long GetPowerSteps(long number, int power)
    {
        long result = 1;
        while (power != 0)
        {
            if (power % 2 == 1)
            {
                result *= number;
            }

            number *= number;
            power /= 2;
        }

        return result;
    }
}

class TupleComparer : IComparer<Tuple<long, long>>
{
    public int Compare(Tuple<long, long> x, Tuple<long, long> y)
    {
        return x.Item2.CompareTo(y.Item2);
    }
}
