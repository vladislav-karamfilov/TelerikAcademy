using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "grade cannot be a negative number!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "minGrade cannot be a negative number!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "maxGrade must be bigger than minGrade!");
        }

        if (grade < minGrade || maxGrade < grade)
        {
            throw new ArgumentOutOfRangeException("grade", string.Format("grade must be between {0} and {1}!", minGrade, maxGrade));
        }

        if (string.IsNullOrWhiteSpace(comments))
        {
            throw new ArgumentOutOfRangeException("comments", "comments cannot be null or empty string!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
