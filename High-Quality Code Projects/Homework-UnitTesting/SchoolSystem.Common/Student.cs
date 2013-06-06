namespace SchoolSystem.Common
{
    using System;

    public class Student
    {
        private const int MinUniqueNumber = 10000;
        private const int MaxUniqueNumber = 99999;
        private const int MinNameLength = 2;
        private const int MaxNameLength = 50;

        private string firstName;
        private string lastName;
        private int uniqueNumber;

        public Student(string firstName, string lastName, int uniqueNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UniqueNumber = uniqueNumber;
        }

        public string FirstName
        {
            get 
            { 
                return this.firstName; 
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("firstName", "Student's first name cannot be empty or null!");
                }

                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException(
                        string.Format("First name too short! It should be at least {0} letters!", MinNameLength), "firstName");
                }

                if (value.Length > MaxNameLength)
                {
                    throw new ArgumentException(
                        string.Format("First name too long! It should be maximum {0} letters!", MaxNameLength), "firstName");
                }

                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("firstName", "Invalid first name! Allowed symbols are only letters and hyphen!");
                    }
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("lastName", "Student's last name cannot be empty or null!");
                }

                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException(
                        string.Format("Last name too short! It should be at least {0} letters!", MinNameLength), "lastName");
                }

                if (value.Length > MaxNameLength)
                {
                    throw new ArgumentException(
                        string.Format("Last name too long! It should be maximum 50 letters!", MaxNameLength), "lastName");
                }

                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("lastName", "Invalid last name! Allowed symbols are only letters and hyphen!");
                    }
                }

                this.lastName = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                if (value < MinUniqueNumber || MaxUniqueNumber < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "uniqueNumber", 
                        string.Format("Student's unique number must be between {0} and {1}!", MinUniqueNumber, MaxUniqueNumber));
                }

                this.uniqueNumber = value;
            }
        }
    }
}
