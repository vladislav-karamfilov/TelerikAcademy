using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr", "Array from which to get the subsequence cannot be null!");
        }

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new IndexOutOfRangeException("startIndex is out of the boundaries of the array!");
        }

        if (count < 0 || count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("count", "count must be between 0 and the length of the array!");
        }

        if (startIndex + count > arr.Length)
        {
            throw new IndexOutOfRangeException(
                string.Format("The count of elements from {0} gets outside the boundaries of the array!", startIndex));
        }

        if (count == 0)
        {
            return new T[0];
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str", "Cannot extract the ending of null string!");
        }

        if (count < 0 || count > str.Length)
        {
            throw new ArgumentOutOfRangeException("count", string.Format("count must be between 0 and {0}", str.Length));
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool IsPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            // Console.WriteLine(ExtractEnding("Hi", 100)); // This will cause exception

            var isTwentyThreePrime = IsPrime(23);
            if (isTwentyThreePrime)
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime");
            }

            var isThirtyThreePrime = IsPrime(33);
            if (isThirtyThreePrime)
            {
                Console.WriteLine("33 is prime.");
            }
            else
            {
                Console.WriteLine("33 is not prime");
            }

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.Message);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (IndexOutOfRangeException ioore)
        {
            Console.WriteLine(ioore.Message);
        }
        catch (InvalidOperationException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }
}
