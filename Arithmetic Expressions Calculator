using System;
using System.Collections.Generic;

class CalculatingArithmeticExpression
{
    static Dictionary<string, int> operatorsPrecedence = new Dictionary<string, int>()
    {
        {"+", 1}, {"-", 1}, {"*", 2}, {"/", 2}
    };

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the value of an arithmetical expression***");
        Console.Write(decorationLine);
        Console.Write("Enter the expression you want to calculate: ");
        // Example -> (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) * pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)
        string inputExpression = Console.ReadLine();
        List<string> allTokens = SeparateToTokens(inputExpression);
        Queue<string> tokensToEvaluate = ParseMathematicalExpression(allTokens);
        double resultOfEvaluation = EvaluateFromTokens(tokensToEvaluate);
        Console.WriteLine("The result of the expression is: " + resultOfEvaluation);
    }

    static double EvaluateFromTokens(Queue<string> tokensToEvaluate)
    {
        Stack<double> resultStack = new Stack<double>();
        while (tokensToEvaluate.Count != 0)
        {
            if (IsNumberToken(tokensToEvaluate.Peek()))
            {
                resultStack.Push(double.Parse(tokensToEvaluate.Dequeue())); // Push numbers to the result stack
            }
            else // The token is operator/function
            {
                switch (tokensToEvaluate.Peek())
                {
                    case "ln":
                        resultStack.Push(Math.Log(resultStack.Pop())); // Takes 1 argument
                        break;
                    case "sqrt":
                        resultStack.Push(Math.Sqrt(resultStack.Pop())); // Takes 1 argument
                        break;
                    case "pow":
                        double power = resultStack.Pop(); // First taking the power
                        double number = resultStack.Pop(); // Taking the number to be raised to a power
                        resultStack.Push(Math.Pow(number, power));
                        break;
                    case "+": // The order doesn't matter
                        resultStack.Push(resultStack.Pop() + resultStack.Pop());
                        break;
                    case "-":
                        double subtrahend = resultStack.Pop();
                        double minuend = resultStack.Pop();
                        resultStack.Push(minuend - subtrahend);
                        break;
                    case "*": // The order doesn't matter
                        resultStack.Push(resultStack.Pop() * resultStack.Pop());
                        break;
                    case "/":
                        double divisor = resultStack.Pop();
                        double numerator = resultStack.Pop();
                        resultStack.Push(numerator / divisor);
                        break;
                }
                tokensToEvaluate.Dequeue();
            }
        }
        return resultStack.Pop(); // The last element from the stack is the result of the expression
    }

    static Queue<string> ParseMathematicalExpression(List<string> tokens)
    {
        Queue<string> result = new Queue<string>();
        Stack<string> operators = new Stack<string>();
        foreach (string token in tokens)
        {
            if (IsNumberToken(token))
            {
                result.Enqueue(token);
            }
            else if (IsFunctionToken(token))
            {
                operators.Push(token);
            }
            else if (token == ",")
            {
                while (operators.Peek() != "(")
                {
                    result.Enqueue(operators.Pop());
                }
            }
            else if (IsOperatorToken(token))
            {
                while (operators.Count != 0 && IsOperatorToken(operators.Peek()))
                {
                    if (operatorsPrecedence[token] <= operatorsPrecedence[operators.Peek()])
                    {
                        result.Enqueue(operators.Pop()); // Enqueue the operator with bigger precedence
                        continue;
                    }
                    break;
                }
                operators.Push(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Peek() != "(")
                {
                    result.Enqueue(operators.Pop()); // Enque all operations between the parentheses
                }
                operators.Pop(); // Removing the "(" from the operations stack
                if (operators.Count != 0 && IsFunctionToken(operators.Peek()))
                {
                    result.Enqueue(operators.Pop());
                }
            }
        }
        // Enqueue all operators left in the stack
        while (operators.Count != 0)
        {
            result.Enqueue(operators.Pop());
        }
        return result;
    }

    static bool IsFunctionToken(string token)
    {
        if (token == "pow" || token == "ln" || token == "sqrt")
        {
            return true;
        }
        return false;
    }

    static bool IsOperatorToken(string token)
    {
        if (token == "+" || token == "-" || token == "*" || token == "/")
        {
            return true;
        }
        return false;
    }

    static bool IsNumberToken(string token)
    {
        double testForNumber = 0d;
        return double.TryParse(token, out testForNumber);
    }

    static List<string> SeparateToTokens(string expression)
    {
        List<string> result = new List<string>();
        string currentToken = string.Empty;
        for (int index = 0; index < expression.Length; index++)
        {
            if (expression[index] == '(' || expression[index] == ')' || expression[index] == ',' || expression[index] == '*' ||
                expression[index] == '/' || expression[index] == '+' || (expression[index] == '-' && !char.IsDigit(expression[index + 1])))
            {
                if (currentToken.Length != 0) // Clear buffer
                {
                    result.Add(currentToken);
                    currentToken = string.Empty;
                }
                result.Add(expression[index].ToString());
                continue;
            }
            if (char.IsDigit(expression[index]) || expression[index] == '.' || expression[index] == '-')
            {
                currentToken += expression[index];
                continue;
            }
            if (char.IsLetter(expression[index]))
            {
                currentToken += expression[index];
                continue;
            }
            else if (currentToken.Length != 0)
            {
                result.Add(currentToken);
                currentToken = string.Empty;
            }
        }
        // Check for last token
        if (currentToken.Length != 0)
        {
            result.Add(currentToken);
        }
        return result;
    }
}
