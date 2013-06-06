using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolHierarchy.Common
{
    public class Teacher : Person, ICommentable
    {
        private List<Discipline> disciplines;
        private string comment;

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set
            {
                this.disciplines = new List<Discipline>();
                foreach (Discipline newDiscipline in value)
                {
                    AddNewDiscipline(newDiscipline);
                }
            }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public Teacher(string name)
            : this(name, new List<Discipline>())
        {
        }
        public Teacher(string name, List<Discipline> disciplines)
        {
            this.Name = name;
            this.Disciplines = disciplines;
        }

        private void AddNewDiscipline(Discipline newDiscipline)
        {
            // Check for existing discipline
            foreach (Discipline discipline in this.disciplines)
            {
                if (newDiscipline.Name == discipline.Name)
                {
                    throw new InvalidOperationException("Teacher already have this discipline!");
                }
            }
            this.disciplines.Add(newDiscipline);
        }
        public void AddDiscipline(Discipline newDiscipline)
        {
            AddNewDiscipline(newDiscipline);
        }
        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Teacher name: " + this.Name);
            foreach (Discipline discipline in this.disciplines)
            {
                result.AppendLine(discipline.ToString());
            }
            if (this.comment != null)
            {
                result.AppendLine(string.Format("Comment: {0}", this.comment));
            }
            return result.ToString();
        }
    }
}
