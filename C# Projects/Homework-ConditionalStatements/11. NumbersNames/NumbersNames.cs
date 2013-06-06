using System;

class NumbersNames
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a number to a text corresponding to its English pronunciation***");
        Console.Write(decorationLine);
        string[] oneToNine = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] elevenToNineteen = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] twentyToNinety = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy","eighty" , "ninety" };
        Console.Write("Enter an integer number in the range [0...999]: ");
        ushort number;
        if (!ushort.TryParse(Console.ReadLine(), out number) || number < 0 || number > 999)
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        int ones = number % 10;
        number /= 10;
        int tens = number % 10;
        number /= 10;
        int hundreds = number % 10;
        Console.Write("Pronunciation -> ");
        if (hundreds != 0)
        {
            if (tens > 1)
            {
                if (ones == 0)
                {
                    Console.WriteLine(oneToNine[hundreds - 1] + " hundred and " + twentyToNinety[tens - 2]);
                }
                else
                {
                    Console.WriteLine(oneToNine[hundreds - 1] + " hundred " + twentyToNinety[tens - 2] + " " + oneToNine[ones - 1]);
                }
            }
            if (tens == 1)
            {
                if (ones == 0)
                {
                    Console.WriteLine(oneToNine[hundreds - 1] + " hundred and ten");
                }
                else
                {
                    Console.WriteLine(oneToNine[hundreds - 1] + " hundred and " + elevenToNineteen[ones - 1]);
                }
            }
            if (tens == 0 && ones != 0)
	        {
                Console.WriteLine(oneToNine[hundreds - 1] + " hundred and " + oneToNine[ones - 1]);
	        }
            if (tens == 0 && ones == 0)
            {
                Console.WriteLine(oneToNine[hundreds - 1] + " hundred");
            }
        }
        else
        {
            if (tens > 1)
            {
                if (ones == 0)
                {
                    Console.WriteLine(twentyToNinety[tens - 2]);
                }
                else
                {
                    Console.WriteLine(twentyToNinety[tens - 2] + " " + oneToNine[ones - 1]);
                }
            }
            if (tens == 1)
            {
                if (ones == 0)
                {
                    Console.WriteLine("ten");
                }
                else
                {
                    Console.WriteLine(elevenToNineteen[ones - 1]);
                }
            }
            if (tens == 0)
            {
                if (ones == 0)
                {
                    Console.WriteLine("zero");
                }
                else
                {
                    Console.WriteLine(oneToNine[ones - 1]);
                }
            }
        }
    }
}
