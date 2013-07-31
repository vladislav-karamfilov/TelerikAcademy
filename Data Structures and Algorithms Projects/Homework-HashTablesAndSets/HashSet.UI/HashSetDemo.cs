namespace HashSet.UI
{
    using System;
    using HashSet.Common;

    public class HashSetDemo
    {
        internal static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting the functionality of the data structure 'Hash set'***");
            Console.Write(decorationLine);

            HashSet<int> years = new HashSet<int>();

            Console.WriteLine("---Add operation---");
            years.Add(1990);
            years.Add(1992);
            years.Add(2013);
            years.Add(2016);
            years.Add(2022);
            Console.WriteLine("Count = " + years.Count);
            Console.WriteLine();

            Console.WriteLine("---Iterator functionality---");
            PrintYears(years);
            Console.WriteLine();

            Console.WriteLine("---Contains operation---");
            Console.WriteLine("Does years set contain {0}? - {1}", 1992, years.Contains(1992));
            Console.WriteLine("Does years set contain {0}? - {1}", 2012, years.Contains(2012));
            Console.WriteLine();

            Console.WriteLine("---Remove operation---");
            Console.WriteLine("Is {0} removed from years set? - {1}", 1996, years.Remove(1996));
            Console.WriteLine("Years set count: " + years.Count);
            Console.WriteLine("Is {0} removed from years set? - {1}", 1990, years.Remove(1990));
            Console.WriteLine("Years set count: " + years.Count);
            Console.WriteLine();

            Console.WriteLine("---UnionWith operation---");
            int[] yearsToUnionWith = new int[] { 2005, 2009, 2021, 2016, 1992, 2013 };
            years.UnionWith(yearsToUnionWith);
            Console.WriteLine("All years after a union with: {0}", string.Join(", ", yearsToUnionWith));
            PrintYears(years);
            Console.WriteLine("Years set count: " + years.Count);
            Console.WriteLine();

            Console.WriteLine("---IntersectWith operation---");
            int[] yearsToIntersectWith = new int[] { 2045, 2025, 2021, 2016, 1999, 2017, 2013 };
            years.IntersectWith(yearsToIntersectWith);
            Console.WriteLine("All years after an intersect with: {0}", string.Join(", ", yearsToIntersectWith));
            PrintYears(years);
            Console.WriteLine("Years set count: " + years.Count);
            Console.WriteLine();

            Console.WriteLine("---Clear operation---");
            years.Clear();
            Console.WriteLine("Years count after clearing: " + years.Count);
        }

        private static void PrintYears(HashSet<int> years)
        {
            foreach (int year in years)
            {
                Console.WriteLine("Year: {0}", year);
            }
        }
    }
}
