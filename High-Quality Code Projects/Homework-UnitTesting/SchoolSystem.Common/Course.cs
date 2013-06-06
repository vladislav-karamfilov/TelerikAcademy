namespace SchoolSystem.Common
{
    using System;
    using System.Collections.Generic;
    
    public class Course
    {
        private const int MaxStudents = 29;

        private string name;
        private IList<Student> students;

        public Course(string name, IList<Student> students)
        {
            this.Name = name;
            this.Students = students;
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
                    throw new ArgumentOutOfRangeException("name", "Course name cannot be null or empty string!");
                }

                this.name = value;
            }
        }


        public IList<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("students", "Course's students list cannot be null!");
                }

                if (value.Count > MaxStudents)
                {
                    throw new ArgumentException(
                        string.Format("Course's list of students cannot have more than {0} students!", MaxStudents), 
                        "students");
                }

                this.students = value;
            }
        }

        public void AddStudent(Student newStudent)
        {
            if (newStudent == null)
            {
                throw new ArgumentNullException("newStudent", "Cannot add null value to the list of students of a course!");
            }

            if (!this.IsStudentAlreadyInCourse(newStudent))
            {
                if (this.Students.Count + 1 <= MaxStudents)
                {
                    this.Students.Add(newStudent);
                }
                else
                {
                    throw new InvalidOperationException(
                        string.Format(
                        "Cannot add student because the limit of {0} students for the course is reached!", MaxStudents));
                }
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format("Student with unique number {0} is already in the course!", newStudent.UniqueNumber));
            }
        }

        private bool IsStudentAlreadyInCourse(Student newStudent)
        {
            foreach (Student student in this.Students)
            {
                if (newStudent.UniqueNumber == student.UniqueNumber)
                {
                    return true;
                }
            }

            return false;
        }

        public bool RemoveStudent(Student student)
        {
            return this.Students.Remove(student);
        }
    }
}
