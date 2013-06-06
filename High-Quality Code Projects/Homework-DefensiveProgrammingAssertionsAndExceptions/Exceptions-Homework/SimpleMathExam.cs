using System;

public class SimpleMathExam : Exam
{
    private const int TotalProblems = 2;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "problemsSolved cannot be a negative number!");
        }

        if (problemsSolved > TotalProblems)
        {
            throw new ArgumentOutOfRangeException(
                "problemsSolved", string.Format("problemsSolved must be less than {0}!", TotalProblems));
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: one problem solved.");
        }
        else
        {
            // All problems solved
            return new ExamResult(6, 2, 6, "Excellent result: all problems solved.");
        }
    }
}
