using System;

namespace SchoolHierarchy.Common
{
    public class Student : Person, ICommentable
    {
        private byte classNumber;
        private string comment;

        public byte ClassNumber
        {
            get { return this.classNumber; }
            set
            {
                if (value == 0 || value > 50)
	            {
                    throw new ArgumentOutOfRangeException("Class number must be a positive number less than 51!");
	            }
                this.classNumber = value;
            }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public Student(string name, byte classNumber)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}\nClass number: {1}", this.Name, this.classNumber);
            if (this.comment != null)
            {
                result += string.Format("\nComment: {0}", this.comment);
            }
            return result;
        }
    }
}
