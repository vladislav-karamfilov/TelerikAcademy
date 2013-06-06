using System;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        day++; // The next day
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                if (month == 12 && day == 32)
                {
                    year++;
                    Console.WriteLine(1 + "." + 1 + "." + year);
                }
                if (day < 32)
                {
                    Console.WriteLine(day + "." + month + "." + year);
                }
                else if (month != 12 && day == 32)
                {
                    Console.WriteLine(1 + "." + (month + 1) + "." + year);
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                if (day < 31)
                {
                    Console.WriteLine(day + "." + month + "." + year);
                }
                else
                {
                    Console.WriteLine(1 + "." + (month + 1) + "." + year);
                }
                break;
            default: // Using it for case 2
                if (year % 400 == 0 || year % 4 == 0) // Leap year
                {
                    if (day < 30)
                    {
                        Console.WriteLine(day + "." + month + "." + year);
                    }
                    else
                    {
                        Console.WriteLine(1 + "." + (month + 1) + "." + year);
                    }
                }
                else
                {
                    if (day < 29)
                    {
                        Console.WriteLine(day + "." + month + "." + year);
                    }
                    else
                    {
                        Console.WriteLine(1 + "." + (month + 1) + "." + year);
                    }
                }
                break;
        }
    }
}