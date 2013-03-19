using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolHierarchy.Common
{
    public class School
    {
        private List<SchoolClass> classes;

        public List<SchoolClass> Classes
        {
            get { return this.classes; }
            set
            {
                this.classes = new List<SchoolClass>();
                foreach (SchoolClass newClass in value)
                {
                    AddNewClass(newClass);
                }
            }
        }

        public School()
            : this(new List<SchoolClass>())
        {
        }
        public School(List<SchoolClass> classes)
        {
            this.Classes = classes;
        }

        private void AddNewClass(SchoolClass newClass)
        {
            // Check for existing class with the same identifier
            foreach (SchoolClass schoolClass in this.classes)
            {
                if (newClass.Identifier == schoolClass.Identifier)
                {
                    throw new InvalidOperationException("There's already such a class in the school!");
                }
            }
            this.classes.Add(newClass);
        }
        public void AddClass(SchoolClass newClass)
        {
            AddNewClass(newClass);
        }
        public void RemoveClass(SchoolClass schoolClass)
        {
            this.classes.Remove(schoolClass);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("***Classes in the school***");
            foreach (SchoolClass schoolClass in this.classes)
            {
                result.Append(schoolClass.ToString());
            }
            return result.ToString();
        }
    }
}
