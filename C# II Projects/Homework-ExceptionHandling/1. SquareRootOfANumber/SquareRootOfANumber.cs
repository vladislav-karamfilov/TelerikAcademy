using System;

class SquareRootOfANumber
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the square root of an integer with exception handling \nfor invalid input***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        try
        {
            int number = int.Parse(Console.ReadLine());
            double squareRoot = CalculateSquareRoot(number);
            Console.WriteLine("The square root of {0} is {1}.", number, squareRoot);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number! The input is not an integer number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number! The input number is too big or too small!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number! Square root operation is only defined for non-negative numbers!");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }

    static double CalculateSquareRoot(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        return Math.Sqrt(number);    
    }
}
