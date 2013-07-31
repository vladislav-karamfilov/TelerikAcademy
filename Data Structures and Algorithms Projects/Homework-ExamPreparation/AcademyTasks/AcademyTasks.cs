using System;
using System.Collections.Generic;

class AcademyTasks
{
    static void Main()
    {
        string[] pleasantnessStrings = 
            Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pleasantness = new int[pleasantnessStrings.Length];
        for (int i = 0; i < pleasantnessStrings.Length; i++)
        {
            pleasantness[i] = int.Parse(pleasantnessStrings[i]);
        }

        int variety = int.Parse(Console.ReadLine());
        
        Console.WriteLine(GetProblemsToSolveCount(pleasantness, variety));
    }

    static int GetProblemsToSolveCount(int[] pleasantness, int variety)
    {
        int minProblemsToSolve = pleasantness.Length;
        for (int i = 0; i < pleasantness.Length - 1; i++)
        {
            for (int j = i + 1; j < pleasantness.Length; j++)
            {
                if (Math.Abs(pleasantness[j] - pleasantness[i]) >= variety)
                {
                    int problemsToSolve = 0;
                    problemsToSolve += (j - i + 1) / 2 + 1;
                    problemsToSolve += (i + 1) / 2;

                    minProblemsToSolve = Math.Min(problemsToSolve, minProblemsToSolve);
                }
            }
        }

        return minProblemsToSolve;
    }
}
