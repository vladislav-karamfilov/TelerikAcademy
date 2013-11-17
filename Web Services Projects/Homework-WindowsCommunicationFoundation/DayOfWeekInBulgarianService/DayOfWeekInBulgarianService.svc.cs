namespace DayOfWeekInBulgarianService
{
    using System;

    public class DayOfWeekInBulgarianService : IDayOfWeekInBulgarianService
    {
        public string GetDayOfWeekInBulgarian(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return "Петък";
                case DayOfWeek.Monday:
                    return "Понеделник";
                case DayOfWeek.Saturday:
                    return "Събота";
                case DayOfWeek.Sunday:
                    return "Неделя";
                case DayOfWeek.Thursday:
                    return "Четвъртък";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Сряда";
                default:
                    throw new ArgumentException("Invalid DateTime object provided!", "date");
            }
        }
    }
}
