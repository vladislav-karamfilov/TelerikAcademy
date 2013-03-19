using System;
using System.Text;

namespace HumansHierarchy.Common
{
    public class Worker : Human
    {
        private decimal? weekSalary;
        private byte? workHoursPerDay;

        public decimal? WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Week salary cannot be negative!");
                    }
                }
                this.weekSalary = value;
            }
        }
        public byte? WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value != null)
                {
                    if (value == 0 || value > 24)
                    {
                        throw new ArgumentOutOfRangeException("Work hours per day must be between 1 and 24!");
                    }
                }
                this.workHoursPerDay = value;
            }
        }

        public Worker(string firstName, string lastName)
            : this(firstName, lastName, null, null)
        {
        }
        public Worker(string firstName, string lastName, decimal? weekSalary, byte? workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            if (this.weekSalary == null)
            {
                throw new InvalidOperationException("Week salary not provided!");
            }
            if (this.workHoursPerDay == null)
            {
                throw new InvalidOperationException("Work hours per day not provided!");
            }
            return this.weekSalary.Value / (5 * this.workHoursPerDay.Value);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine(string.Format("Week salary: {0:C2}", this.weekSalary));
            result.AppendLine("Work hours per day: " + this.workHoursPerDay);
            result.AppendLine(string.Format("Earned money per hour: {0:C2}", this.MoneyPerHour()));
            return result.ToString();
        }
    }
}
