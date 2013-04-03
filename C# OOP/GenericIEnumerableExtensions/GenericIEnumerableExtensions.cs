using System;
using System.Collections.Generic;

namespace GenericIEnumerableExtensions
{
    public static class GenericIEnumerableExtensions
    {
        // Finding the sum of the elements in an enumeration that implements IEnumerable<T>
        public static decimal Sum<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration != null)
            {
                IEnumerator<T> enumerator = enumeration.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("The enumeration is empty!");
                }
                else
                {
                    decimal sum = Convert.ToDecimal(enumerator.Current);
                    while (enumerator.MoveNext())
                    {
                        sum += Convert.ToDecimal(enumerator.Current);
                    }
                    return sum;
                }
            }
            else
            {
                throw new NullReferenceException("The enumeration is not instantiated!");
            }
        }

        // Finding the product of the elements in an enumeration that implements IEnumerable<T>
        public static decimal Product<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration != null)
            {
                IEnumerator<T> enumerator = enumeration.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("The enumeration is empty!");
                }
                else
                {
                    decimal product = Convert.ToDecimal(enumerator.Current);
                    while (enumerator.MoveNext())
                    {
                        product *= Convert.ToDecimal(enumerator.Current);
                    }
                    return product;
                }
            }
            else
            {
                throw new NullReferenceException("The enumeration is not instantiated!");
            }
        }

        // Finding the minimal element in an enumeration that implements IEnumerable<T>
        public static T Min<T>(this IEnumerable<T> enumeration)
            where T : IComparable<T>
        {
            if (enumeration != null)
            {
                IEnumerator<T> enumerator = enumeration.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("The enumeration is empty!");
                }
                else
                {
                    T min = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.CompareTo(min) < 0)
                        {
                            min = enumerator.Current;
                        }
                    }
                    return min;
                }
            }
            else
            {
                throw new NullReferenceException("The enumeration is not instantiated!");
            }
        }

        // Finding the maximal element in an enumeration that implements IEnumerable<T>
        public static T Max<T>(this IEnumerable<T> enumeration)
            where T : IComparable<T>
        {

            if (enumeration != null)
            {
                IEnumerator<T> enumerator = enumeration.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("The enumeration is empty!");
                }
                else
                {
                    T max = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.CompareTo(max) > 0)
                        {
                            max = enumerator.Current;
                        }
                    }
                    return max;
                }
            }
            else
            {
                throw new NullReferenceException("The enumeration is not instantiated!");
            }
        }
        
        // Finding the average of the elements in an enumeration that implements IEnumerable<T>
        public static decimal Average<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration != null)
            {
                IEnumerator<T> enumerator = enumeration.GetEnumerator();
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("The enumeration is empty!");
                }
                else
                {
                    uint count = 1;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }
                    return enumeration.Sum()/count;
                }
            }
            else
            {
                throw new NullReferenceException("The enumeration is not instantiated!");
            }
        }
    }
}
