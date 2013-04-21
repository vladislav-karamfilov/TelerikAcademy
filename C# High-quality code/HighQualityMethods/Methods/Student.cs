using System;
using System.Text;

namespace Methods
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string birthTown;
        private string hobby;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Student's first name cannot be empty or null!");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Student's first name too short! It should be at least 2 letters!");
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Student's first name too long! It should be maximum 50 letters!");
                }

                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid first name! Allowed symbols are only letters and hyphen!");
                    }
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Student's last name cannot be empty or null!");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Student's last name too short! It should be at least 2 letters!");
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Student's last name too long! It should be maximum 50 letters!");
                }

                foreach (char symbol in value)
                {
                    if (!char.IsLetter(symbol) && symbol != '-')
                    {
                        throw new ArgumentOutOfRangeException("Invalid last name! Allowed symbols are only letters and hyphen!");
                    }
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public string BirthTown
        {
            get { return this.birthTown; }
            set { this.birthTown = value; }
        }

        public string Hobby
        {
            get { return this.hobby; }
            set { this.hobby = value; }
        }

        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new NullReferenceException("The other student cannot be null!");
            }

            bool isOlderThan = this.DateOfBirth < other.DateOfBirth;
            return isOlderThan;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Student: {0} {1}\n", this.FirstName, this.LastName);
            if (this.DateOfBirth != default(DateTime))
            {
                output.AppendFormat("Born on: {0}", this.DateOfBirth.ToShortDateString());
            }

            if (this.BirthTown != null)
            {
                output.AppendFormat(" at {0}\n", this.BirthTown);
            }

            if (this.Hobby != null)
            {
                output.AppendFormat("Hobby: {0}\n", this.Hobby);
            }

            return output.ToString();
        }
    }
}
