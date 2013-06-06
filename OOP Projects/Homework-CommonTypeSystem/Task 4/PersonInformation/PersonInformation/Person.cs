using System;
using System.Text;

namespace PersonInformation
{
    public class Person
    {
        #region Private instance fields
        private string firstName;
        private string middleName;
        private string lastName;
        private int? age;
        #endregion

        #region Public properties
        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Names cannot be empty or null!");
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
        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Names cannot be empty or null!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Middle name too short! It should be at least 2 letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Middle name too long! It should be maximum 50 letters!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid name! Allowed symbols are only letters and hyphen!");
                    }
                }
                this.middleName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Names cannot be empty or null!");
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
        public int? Age
        {
            get { return this.age; }
            set
            {
                if (value != null)
                {
                    if (value <= 0 || value > 125)
                    {
                        throw new ArgumentOutOfRangeException("Invalid age! Person's age must be in the range [1..125]!");
                    }
                }
                this.age = value;
            }
        }
        #endregion

        #region Constructors
        public Person(string firstName, string middleName, string lastName)
            : this(firstName, middleName, lastName, null)
        {
        }
        public Person(string firstName, string middleName, string lastName, int? age)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Age = age;
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Middle name: " + this.MiddleName);
            result.AppendLine("Last name: " + this.LastName);
            result.Append("Age: ");
            if (this.Age != null)
            {
                result.AppendLine(this.Age.ToString());
            }
            else
            {
                result.AppendLine("[unspecified]");
            }
            return result.ToString();
        }
        #endregion

    }
}
