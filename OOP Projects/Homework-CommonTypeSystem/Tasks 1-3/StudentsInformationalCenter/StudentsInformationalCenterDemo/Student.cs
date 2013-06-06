using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentsInformationalCenterDemo
{
    public class Student : IComparable<Student>, ICloneable
    {
        #region Private fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private byte course;
        private University university;
        private Faculty faculty;
        private Specialty specialty;
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
        public string Ssn
        {
            get { return this.ssn; }
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid SSN! 10 digits must be provided!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Invalid SSN! It consist only of digits!");
                    }
                }
                this.ssn = value;
            }
        }
        public string Address
        {
            get { return this.address; }
            set
            {
                foreach (char symbol in value)
                {
                    if (!char.IsLetterOrDigit(symbol) && symbol != ' ' && symbol != ',' && symbol != '#' && 
                        symbol != ';' && symbol != ':' && symbol != '\"' && symbol != '\'')
                    {
                        throw new ArgumentException("Invalid address provided!");
                    }
                }
                this.address = value;
            }
        }
        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid phone number! Mobile phones consist of 10 digits!");
                }
                foreach (char symbol in value)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Invalid phone number! You must use only digits!");
                    }
                }
                this.mobilePhone = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                string emailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(value, emailRegex))
                {
                    throw new ArgumentException("Invalid e-mail provided!");
                }
                this.email = value;
            }
        }
        public byte Course
        {
            get { return this.course; }
            set
            {
                if (value == 0 || value > 8)
                {
                    throw new ArgumentOutOfRangeException("Invalid course! Courses are in the range [1..8]!");
                }
                this.course = value;
            }
        }
        public University University
        {
            get { return this.university; }
            set { this.university = value; }
        }
        public Faculty Faculty
        {
            get { return this.faculty; }
            set { this.faculty = value; }
        }
        public Specialty Specialty
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }
        #endregion

        #region Constructor
        public Student(string firstName, string middleName, string lastName, string ssn, string address, string mobilePhone,
            string email, byte course, University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }
        #endregion

        #region Public methods
        public override bool Equals(object parameter)
        {
            Student student = parameter as Student;
            if ((object)student == null)
            {
                return false;
            }
            if (Object.Equals(this.Ssn, student.Ssn))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            // Using a small prime number to reduce the chance of collisions and overflow of int type
            int prime = 7;
            int result = 1;
            unchecked // Using "unchecked" so if the result is evaluated to overflow it is truncated
            {
                result = result * prime + this.FirstName.GetHashCode();
                result = result * prime + this.MiddleName.GetHashCode();
                result = result * prime + this.LastName.GetHashCode();
                result = result * prime + this.Ssn.GetHashCode();
                result = result * prime + this.MobilePhone.GetHashCode();
                result = result * prime + this.Email.GetHashCode();
                result = result * prime + this.Address.GetHashCode();
                result = result * prime + this.University.GetHashCode();
                result = result * prime + this.Faculty.GetHashCode();
                result = result * prime + this.Specialty.GetHashCode();
            }
            return result;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("---Student information---");
            result.AppendLine("First name: " + this.FirstName);
            result.AppendLine("Middle name: " + this.MiddleName);
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine("SSN: " + this.Ssn);
            result.AppendLine("Permanent address: " + this.Address);
            result.AppendLine("Mobile phone: " + this.MobilePhone);
            result.AppendLine("E-mail: " + this.Email);
            result.AppendLine("University: " + this.University);
            result.AppendLine("Faculty: " + this.Faculty);
            result.AppendLine("Specialty: " + this.Specialty);
            return result.ToString();
        }
        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }
        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }
        object ICloneable.Clone() // The method from the ICloneable interface
        {
            return this.Clone();
        }
        public Student Clone() // The class method for deep cloning
        {
            string cloneFirstName = string.Copy(this.FirstName);
            string cloneMiddleName = string.Copy(this.MiddleName);
            string cloneLastName = string.Copy(this.LastName);
            string cloneSsn = string.Copy(this.Ssn);
            string cloneAddress = string.Copy(this.Address);
            string cloneMobilePhone = string.Copy(this.MobilePhone);
            string cloneEmail = string.Copy(this.Email);
            return new Student(cloneFirstName, cloneMiddleName, cloneLastName, cloneSsn, cloneAddress, cloneMobilePhone, cloneEmail,
                this.Course, this.University, this.Faculty, this.Specialty); // Last 4 are value types so they are deep cloned by default
        }
        public int CompareTo(Student other)
        {
            // The other student is not valid reference so the current is greater
            if (other == null)
            {
                return 1;
            }
            // Getting the concatenations of the names of both students so they can be easily compared
            string currentStudentNames = this.FirstName + this.MiddleName + this.LastName;
            string otherStudentNames = other.FirstName + other.MiddleName + other.LastName;
            int namesComparison = currentStudentNames.CompareTo(otherStudentNames);
            if (namesComparison != 0) // The names are different
            {
                return namesComparison;
            }
            else // The names are equal so the result is the comparison of the SSNs 
            {
                return this.Ssn.CompareTo(other.Ssn);
            }
        }
        #endregion
    }
}