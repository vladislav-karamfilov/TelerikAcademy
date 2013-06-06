using System;

class WorkdaysBetweenTodayAndSomeDate
{
    static DateTime[] publicHolidays = { new DateTime(2013, 1, 1), new DateTime(2013, 3, 3), new DateTime(2013, 5, 1), 
                                         new DateTime(2013, 5, 2), new DateTime(2013, 5, 3), new DateTime(2013, 5, 4), 
                                         new DateTime(2013, 5, 5), new DateTime(2013, 5, 6), new DateTime(2013, 5, 24),
                                         new DateTime(2013, 9, 6), new DateTime(2013, 9, 22), new DateTime(2013, 11, 1),
                                         new DateTime(2013, 12, 24), new DateTime(2013, 12, 25), new DateTime(2013, 12, 26),
                                         new DateTime(2013, 12, 31) };
        
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the number of workdays between today and some date***");
        Console.Write(decorationLine);
        Console.WriteLine("Enter to what date from today to calculate the workdays in format YYYY/MM/DD: ");
        string[] inputDate = Console.ReadLine().Split('/');
        int year = int.Parse(inputDate[0]);
        int month = int.Parse(inputDate[1]);
        int day = int.Parse(inputDate[2]);
        DateTime toDate = new DateTime(year, month, day);
        int workdays = CalculateWorkdays(toDate);
        Console.WriteLine("All workdays from today to {0} are {1}.", toDate.ToShortDateString(), workdays);
    }

    static int CalculateWorkdays(DateTime toDate)
    {
        int workdays = 0;
        DateTime today = DateTime.Today;
        while (today.Date != toDate.Date)
        {
            today = today.AddDays(1);
            if (today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday)
            {
                continue;
            }
            foreach (DateTime holiday in publicHolidays)
            {
                if (today.Date == holiday.Date)
                {
                    continue;
                }
            }
            workdays++;
        }
        return workdays;
    }
}
