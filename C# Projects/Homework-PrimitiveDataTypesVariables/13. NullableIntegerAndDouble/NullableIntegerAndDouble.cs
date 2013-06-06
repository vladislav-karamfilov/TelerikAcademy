using System;

class NullableIntegerAndDouble
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Assigning \"null\" to integer and double variables\nand adding some values and \"null\" to them***");
        Console.Write(decorationLine);
        int? integerVariable = null;
        double? doubleVariable = null;
        Console.WriteLine("The initial values are \"{0}\" and \"{1}\".", integerVariable, doubleVariable);
        Console.Write("Enter an integer to add it to the initial integer variable: ");
        int enteredIntegerValue = int.Parse(Console.ReadLine());
        Console.WriteLine("Adding {0} to the integer variable -> \"{1}\".", enteredIntegerValue, enteredIntegerValue + integerVariable);
        Console.Write("Enter a floating-point to add it to the initial double variable: ");
        double enteredDoubleValue = double.Parse(Console.ReadLine());
        Console.WriteLine("Adding {0} to the double variable -> \"{1}\".", enteredDoubleValue, enteredDoubleValue + doubleVariable);
        Console.WriteLine("Adding \"null\" to the initial integer variable -> \"{0}\".", integerVariable + null);
        Console.WriteLine("Adding \"null\" to the initial double variable -> \"{0}\".", doubleVariable + null);
    }
}

