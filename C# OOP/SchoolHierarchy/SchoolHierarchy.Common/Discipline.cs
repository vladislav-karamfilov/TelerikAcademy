using System;

namespace SchoolHierarchy.Common
{
    public class Discipline : ICommentable
    {
        private string name;
        private byte numberOfLectures;
        private byte numberOfExercises;
        private string comment;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Discipline name cannot be null of empty!");
                }
                this.name = value;
            }
        }
        public byte NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set
            {
                if (value == 0 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("The number of lectures must be a positive number less than 51!");
                }
                this.numberOfLectures = value;
            }
        }
        public byte NumberOfExercises
        {
            get { return this.numberOfExercises; }
            set
            {
                if (value == 0 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("The number of exercises must be a positive number less than 51!");
                }
                this.numberOfExercises = value;
            }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public Discipline(string name, byte numberOfLectures, byte numberOfExercises)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }

        public override string ToString()
        {
            string result = string.Format("Discipline: {0}\nNumber of lectures: {1}\nNumber of exercises: {2}",
                this.name, this.numberOfLectures, this.numberOfExercises);
            if (this.comment != null)
            {
                result += string.Format("\nComment: {0}", this.comment);
            }
            return result;
        }
    }
}
