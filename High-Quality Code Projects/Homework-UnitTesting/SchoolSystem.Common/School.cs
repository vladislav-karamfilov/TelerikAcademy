namespace SchoolSystem.Common
{
    using System;
    using System.Collections.Generic;
    
    public class School
    {
        private string name;
        private IList<Course> courses;

        public School(string name, IList<Course> courses)
        {
            this.Name = name;
            this.Courses = courses;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("name", "School name cannot be null or empty string!");
                }

                this.name = value;
            }
        }

        public IList<Course> Courses
        {
            get
            {
                return this.courses;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("courses", "School's courses list cannot be null!");
                }

                this.courses = value;
            }
        }
    }
}
