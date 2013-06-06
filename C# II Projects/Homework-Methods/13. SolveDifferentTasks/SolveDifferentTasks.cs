using System;
using System.Text;

class SolveDifferentTasks
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Solving tasks depending on the user's choice***");
        Console.Write(decorationLine);
        string choice = null;
        do {
            Console.WriteLine(".:Menu:.");
            Console.WriteLine("1. Reverse the digits of a number");
            Console.WriteLine("2. Calculate the average of a sequence of integers");
            Console.WriteLine("3. Solve a linear equation a * x + b = 0");
            Console.WriteLine("4. Exit");
            Console.Write("Your choice: ");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Write("Enter a number: ");
                long number = long.Parse(Console.ReadLine());
                if (ValidateInput(number))
                {
                    Console.WriteLine("The reversed number is: " + ReverseDigits(number));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input! The number must be non-negative!");
                    Console.WriteLine();
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter how many integers the sequence has: ");
                uint length = uint.Parse(Console.ReadLine());
                if (ValidateInput(length))
                {
                    int[] numbers = new int[length];
                    EnterSequence(numbers, length);
                    Console.WriteLine("The average of the sequence is: " + Average(numbers, length));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input! The sequence can't have 0 elements!");
                    Console.WriteLine();
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter the coefficient a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Enter the coefficient b: ");
                double b = double.Parse(Console.ReadLine());
                if (ValidateInput(a))
                {
                    Console.WriteLine("The root of the equation is: " + SolveLinearEquation(a, b));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input! The coefficient a cannot be 0!");
                    Console.WriteLine();
                }
            }
        } 
        while(choice != "4");
    }

    static bool ValidateInput(double a)
    {
        if (a != 0.0)
        {
            return true;
        }
        return false;
    }

    static bool ValidateInput(long number)
    {
        if (number >= 0)
        {
            return true;
        }
        return false;
    }

    static bool ValidateInput(uint length)
    {
        if (length != 0)
        {
            return true;
        }
        return false;
    }

    static double SolveLinearEquation(double a, double b)
    {
        return -b / a;
    }

    static double Average(int[] numbers, uint lenght)
    {
        long sum = 0; 
        foreach (int number in numbers)
        {
            sum += number;
        }
        return (double)sum / lenght;
    }

    static void EnterSequence(int[] numbers, uint length)
    {
        for (int index = 0; index < length; index++)
		{
            Console.Write("Enter element {0}: ", index + 1);
            numbers[index] = int.Parse(Console.ReadLine());	 
		}
    }

    static long ReverseDigits(long number)
    {
        StringBuilder numberString = new StringBuilder(number.ToString());
        int digits = numberString.Length;
        for (int digit = 0; digit < digits / 2; digit++)
        {
            if (numberString[digit] != numberString[digits - digit - 1])
            {
                char temp = numberString[digit];
                numberString[digit] = numberString[digits - digit - 1];
                numberString[digits - digit - 1] = temp;
            }
        }
        long result = long.Parse(numberString.ToString());
        return result;
    }
}
