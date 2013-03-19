using System;
using System.Text;

namespace HumansHierarchy.Common
{
    public class Student : Human
    {
        private double? grade;

        public double? Grade
        {
            get { return this.grade; }
            set
            {
                if (value != null)
                {
                    if (value < 2 || value > 6)
                    {
                        throw new ArgumentOutOfRangeException("The grade must be between 2 and 6!");
                    }
                }
                this.grade = value;
            }
        }

        public Student(string firstName, string lastName)
            : this(firstName, lastName, null)
        {
        }
        public Student(string firstName, string lastName, double? grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine("Grade: " + this.grade);
            return result.ToString();
        }
    }
}
