using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolHierarchy.Common
{
    public class SchoolClass : ICommentable
    {
        private string identifier;
        private List<Teacher> teachers;
        private List<Student> students;
        private string comment;
        
        public string Identifier
        {
            get { return this.identifier; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
	            {
		            throw new ArgumentOutOfRangeException("Class identifier cannot be null or empty!");
	            }
                this.identifier = value;
            }
        }
        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }
        public List<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = new List<Student>();
                foreach (Student newStudent in value)
                {
                    AddNewStudent(newStudent);
                }
            }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public SchoolClass(string identifier)
            : this(identifier, new List<Student>(), new List<Teacher>())
        {
        }
        public SchoolClass(string identifier, List<Student> students, List<Teacher> teachers)
        {
            this.Identifier = identifier;
            this.Students = students;
            this.Teachers = teachers;
        }

        private void AddNewStudent(Student newStudent)
        {
            foreach (Student student in this.students)
            {
                if (newStudent.ClassNumber == student.ClassNumber)
                {
                    throw new InvalidOperationException("There's already a student with this class number in the class!");
                }
            }
            this.students.Add(newStudent);
        }
        public void AddStudent(Student newStudent)
        {
            AddNewStudent(newStudent);
        }
        public void AddTeacher(Teacher newTeacher)
        {
            this.teachers.Add(newTeacher);
        }
        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Class: " + this.identifier);
            result.AppendLine("---Students in the class---");
            foreach (Student student in this.students)
            {
                result.AppendLine(student.ToString());
            }
            result.AppendLine();
            result.AppendLine("---Teachers of the class---");
            foreach (Teacher teacher in this.teachers)
            {
                result.AppendLine(teacher.ToString());
            }
            if (this.comment != null)
            {
                result.AppendLine(string.Format("---Comment---\n{0}", this.comment));
            }
            return result.ToString();
        }
    }
}
