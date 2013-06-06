namespace Methods
{
    using System;

    public class MethodsDemo
    {
        public static void Main()
        {
            Console.Write("The area of the triangle with sides 3, 4 and 5: ");
            Console.WriteLine(GeometricalOperations.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine();

            Console.Write("The English propunciation of the digit 5: ");
            Console.WriteLine(ConversionOperations.DigitToString(5));
            Console.WriteLine();

            Console.Write("The maximum element of 5, -1, 3, 2, 14, 2, 3: ");
            Console.WriteLine(StatisticalOperations.FindMax(5, -1, 3, 2, 14, 2, 3));
            Console.WriteLine();

            Console.Write("The number 1.1251251253 with precision of 5 digits: ");
            ConsolePrinter.PrintNumber(1.1251251253, 5);
            Console.WriteLine();

            Console.Write("The percentage of 52.1: ");
            ConsolePrinter.PrintPercent(52.1, 3);
            Console.WriteLine();

            Console.Write("The aligned string 'I am a string!': ");
            ConsolePrinter.PrintAligned("I am a string!", 20);
            Console.WriteLine();

            Console.Write("The distance between the points (2, 6.2) and (5.21, -3.33): ");
            Console.WriteLine(GeometricalOperations.CalculateDistance(2, 6.2, 5.21, -3.33));
            Console.WriteLine();

            Console.WriteLine("Is the line formed by points (2, 5) and (2, 6) horizontal? -> {0}\n",
                GeometricalOperations.IsHorizontalLine(2, 5, 2, 6));
            
            Console.WriteLine("Is the line formed by points (2, 5) and (2, 6) vertical? -> {0}\n",
                GeometricalOperations.IsVerticalLine(2, 5, 2, 6));
            
            Student peter = new Student("Peter", "Ivanov");
            peter.DateOfBirth = new DateTime(1992, 03, 17);
            peter.BirthTown = "Sofia";
            Console.WriteLine(peter);
            
            Student stella = new Student("Stella", "Markova");
            stella.DateOfBirth = new DateTime(1992, 11, 03);
            stella.BirthTown = "Vidin";
            stella.Hobby = "gamer";
            Console.WriteLine(stella);
            
            Console.WriteLine("Is {0} older than {1}? -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
