using System;

public class CSharpExam : Exam
{
    private const int MaxScore = 100;

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("score", "score cannot be a negative number!");
        }

        if (score > MaxScore)
        {
            throw new ArgumentOutOfRangeException("score", string.Format("score cannot be bigger than {0}!", MaxScore));
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, MaxScore, "Exam results calculated by score.");
    }
}
