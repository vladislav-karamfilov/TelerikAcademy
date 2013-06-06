using System;

class CheckForCorrectlyPutBrackets
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if the brackets in an expression are put correctly***");
        Console.Write(decorationLine);
        Console.Write("Enter an expression: ");
        string expression = Console.ReadLine();
        if (CheckBrackets(expression))
        {
            Console.WriteLine("The brackets are put correctly!");
        }
        else
        {
            Console.WriteLine("The brackets are not put correctly!");
        }
    }

    static bool CheckBrackets(string expression)
    {
        int openedBrackets = 0;
        foreach (char symbol in expression)
        {
            if (openedBrackets < 0)
            {
                break;
            }
            if (symbol == '(')
            {
                openedBrackets++;
            }
            if (symbol == ')')
            {
                openedBrackets--;
            }
        }
        return openedBrackets == 0;
    }
}
