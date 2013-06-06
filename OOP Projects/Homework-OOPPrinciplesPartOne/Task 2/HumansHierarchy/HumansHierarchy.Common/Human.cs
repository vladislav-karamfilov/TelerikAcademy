using System;

namespace HumansHierarchy.Common
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Person's name cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name too short! It should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("First name too long! It should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Person's name cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name too short! It should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Last name too long! It should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.lastName = value;
            }
        }
    }
}
