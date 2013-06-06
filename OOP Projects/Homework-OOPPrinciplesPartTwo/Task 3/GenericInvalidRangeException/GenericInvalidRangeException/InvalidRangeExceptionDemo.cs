using System;
using System.Globalization;

namespace GenericInvalidRangeException
{
    class InvalidRangeExceptionDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Invalid range exception handling with integers and dates***");
            Console.Write(decorationLine);

            Console.WriteLine("---Invalid range exception handling with integers---");
            try
            {
                Console.Write("Enter an integer out of the range [{0}..{1}] to see the exception: ", 1, 100);
                int number = int.Parse(Console.ReadLine());
                if (number < 1 || number > 100)
                {
                    throw new InvalidRangeException<int>("The number is out of the range!", 1, 100);
                }
                else
                {
                    Console.WriteLine("The entered number is in the correct range!");
                }
            }
            catch (InvalidRangeException<int> irei)
            {
                Console.WriteLine(irei);
            }
            Console.WriteLine();

            Console.WriteLine("---Invalid range exception handling with dates---");
            try
            {
                DateTime startDate = new DateTime(1980, 1, 1);
                DateTime endDate = new DateTime(2013, 12, 31);
                Console.Write("Enter a date out of the range [{0}..{1}] to see the exception: ", "1.1.1980", "31.12.2013");
                DateTime date;
                DateTime.TryParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                if (date < startDate || date > endDate)
                {
                    throw new InvalidRangeException<DateTime>(startDate, endDate);
                }
                else
                {
                    Console.WriteLine("The entered date is in the correct range!");
                }
            }
            catch (InvalidRangeException<DateTime> iredt)
            {
                Console.WriteLine("The date must be in the range [{0}..{1}]!",
                    iredt.Start.ToShortDateString(), iredt.End.ToShortDateString());
            }
        }
    }
}
