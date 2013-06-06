namespace Methods
{
    using System;

    public static class StatisticalOperations
    {
        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Provided parameter cannot be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("No elements are provided!");
            }

            int max = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }
    }
}