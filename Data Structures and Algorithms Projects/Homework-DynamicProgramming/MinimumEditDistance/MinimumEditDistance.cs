using System;

class MinimumEditDistance
{
    const double ReplaceLetterCost = 1d;
    const double DeleteLetterCost = 0.9d;
    const double InsertLetterCost = 0.8d;

    static double[,] editDistances;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the minimal sum of costs for edit operations used to transform");
        Console.WriteLine("the word X to the word Y***");
        Console.Write(decorationLine);

        Console.WriteLine("Cost(replace a letter) = {0}", ReplaceLetterCost);
        Console.WriteLine("Cost(delete a letter) = {0}", DeleteLetterCost);
        Console.WriteLine("Cost(insert a letter) = {0}", InsertLetterCost);
        Console.WriteLine();

        string sourceWord = "source";
        string targetWord = "target";

        double minEditDistance = GetMinimumEditDistance(sourceWord, targetWord);
        Console.WriteLine("Minimum edit distance between the words '{0}' and '{1}' is {2}",
            sourceWord, targetWord, minEditDistance);
        Console.WriteLine();

        Console.WriteLine("The operations are:");
        PrintOperations(sourceWord, targetWord, sourceWord.Length, targetWord.Length);
    }

    static void PrintOperations(string sourceWord, string targetWord, int sourceIndex, int targetIndex)
    {
        if (targetIndex == 0)
        {
            for (targetIndex = 1; targetIndex <= sourceIndex; targetIndex++)
            {
                Console.WriteLine("Delete the letter '{0}' -> cost {1}", 
                    sourceWord[targetIndex - 1], DeleteLetterCost);
            }
        }
        else if (sourceIndex == 0)
        {
            for (sourceIndex = 1; sourceIndex <= targetIndex; sourceIndex++)
            {
                Console.WriteLine("Insert at position {0} letter '{1}' -> cost {2}",
                    sourceIndex - 1, targetWord[sourceIndex - 1], InsertLetterCost);
            }
        }
        else if (sourceIndex > 0 && targetIndex > 0)
        {
            double replaceCost = GetReplaceLetterCost(sourceWord[sourceIndex - 1], targetWord[targetIndex - 1]);
            if (editDistances[sourceIndex, targetIndex] ==
                editDistances[sourceIndex - 1, targetIndex - 1] + replaceCost)
            {
                PrintOperations(sourceWord, targetWord, sourceIndex - 1, targetIndex - 1);
                if (replaceCost > 0)
                {
                    Console.WriteLine("Replace the letter '{0}' with the letter '{1}' -> cost {2}",
                        sourceWord[sourceIndex - 1], targetWord[targetIndex - 1], ReplaceLetterCost);
                }
            }
            else if (editDistances[sourceIndex, targetIndex] ==
                editDistances[sourceIndex, targetIndex - 1] + InsertLetterCost)
            {
                PrintOperations(sourceWord, targetWord, sourceIndex, targetIndex - 1);
                Console.WriteLine("Insert at position {0} letter '{1}' -> cost {2}",
                    sourceIndex - 1, targetWord[targetIndex - 1], InsertLetterCost);
            }
            else if (editDistances[sourceIndex, targetIndex] ==
                editDistances[sourceIndex - 1, targetIndex] + DeleteLetterCost)
            {
                PrintOperations(sourceWord, targetWord, sourceIndex - 1, targetIndex);
                Console.WriteLine("Delete the letter '{0}' -> cost {1}", 
                    sourceWord[sourceIndex - 1], DeleteLetterCost);
            }

        }
    }

    static double GetMinimumEditDistance(string sourceWord, string targetWord)
    {
        if (string.IsNullOrEmpty(sourceWord))
        {
            if (string.IsNullOrEmpty(targetWord))
            {
                return 0d;
            }

            return targetWord.Length;
        }

        if (string.IsNullOrEmpty(targetWord))
        {
            if (string.IsNullOrEmpty(sourceWord))
            {
                return 0d;
            }

            return sourceWord.Length;
        }

        editDistances = new double[sourceWord.Length + 1, targetWord.Length + 1];
        for (int i = 0; i < editDistances.GetLength(0); i++)
        {
            editDistances[i, 0] = i * DeleteLetterCost;
        }

        for (int i = 0; i < editDistances.GetLength(1); i++)
        {
            editDistances[0, i] = i * InsertLetterCost;
        }

        double replaceCost = 0d;
        double deleteCost = 0d;
        double insertCost = 0d;
        for (int i = 1; i < editDistances.GetLength(0); i++)
        {
            for (int j = 1; j < editDistances.GetLength(1); j++)
            {
                replaceCost = editDistances[i - 1, j - 1] +
                    GetReplaceLetterCost(sourceWord[i - 1], targetWord[j - 1]);
                deleteCost = editDistances[i - 1, j] + DeleteLetterCost;
                insertCost = editDistances[i, j - 1] + InsertLetterCost;

                editDistances[i, j] = Math.Min(Math.Min(replaceCost, deleteCost), insertCost);
            }
        }

        return editDistances[sourceWord.Length, targetWord.Length];
    }

    static double GetReplaceLetterCost(char a, char b)
    {
        if (a != b)
        {
            return ReplaceLetterCost;
        }

        return 0;
    }
}
