using System;

namespace SchoolHierarchy.Common
{
    public abstract class Person
    {
        private string name;

        public string Name 
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Person's name cannot be empty or null!");
                }
                string[] names = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length < 2)
                {
                    throw new ArgumentException("Only one name provided! At least two names required!");
                }
                foreach (string name in names)
                {
                    if (name.Length < 2)
                    {
                        throw new ArgumentException("First and/or last name too short! They should be at least 2 letters!");
                    }
                    if (name.Length > 50)
                    {
                        throw new ArgumentException("First and/or last name too long! They should be maximum 50 letters!");
                    }
                    foreach (char symbol in name)
                    {
                        if (!char.IsLetter(symbol) && symbol != '-')
                        {
                            throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                        }
                    }
                }
                this.name = value; 
            }
        }
    }
}
