using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentOutOfRangeException("firstName", "Student's first name cannot be empty or null!");
        }

        if (firstName.Length < 2)
        {
            throw new ArgumentException("First name too short! It should be at least 2 letters!", "firstName");
        }

        if (firstName.Length > 50)
        {
            throw new ArgumentException("First name too long! It should be maximum 50 letters!", "firstName");
        }

        foreach (char symbol in firstName)
        {
            if (!char.IsLetter(symbol) && symbol != '-')
            {
                throw new ArgumentOutOfRangeException("firstName", "Invalid first name! Allowed symbols are only letters and hyphen!");
            }
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentOutOfRangeException("lastName", "Student's last name cannot be empty or null!");
        }

        if (lastName.Length < 2)
        {
            throw new ArgumentException("Last name too short! It should be at least 2 letters!", "lastName");
        }

        if (lastName.Length > 50)
        {
            throw new ArgumentException("Last name too long! It should be maximum 50 letters!", "lastName");
        }

        foreach (char symbol in lastName)
        {
            if (!char.IsLetter(symbol) && symbol != '-')
            {
                throw new ArgumentOutOfRangeException("lastName", "Invalid last name! Allowed symbols are only letters and hyphen!");
            }
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("Exams list cannot be null!");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Exams list cannot be empty!");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("Exams list cannot be null!");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Exams list cannot be empty!");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
