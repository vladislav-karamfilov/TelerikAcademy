using System;

namespace GenericList.Data
{
    public static class GenericListExtensions
    {
        // Extension method for finding the minimal element in a list
        public static T Min<T>(this GenericList<T> list)
            where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot find the minimal element in an empty list!");
            }
            T min = list[0];
            for (int index = 1; index < list.Count; index++)
            {
                if (list[index].CompareTo(min) < 0)
                {
                    min = list[index];
                }
            }
            return min;
        }
        // Extension method for finding the maximal element in a list
        public static T Max<T>(this GenericList<T> list)
            where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot find the maximal element in an empty list!");
            }
            T max = list[0];
            for (int index = 1; index < list.Count; index++)
            {
                if (list[index].CompareTo(max) > 0)
                {
                    max = list[index];
                }
            }
            return max;
        }
    }
}
