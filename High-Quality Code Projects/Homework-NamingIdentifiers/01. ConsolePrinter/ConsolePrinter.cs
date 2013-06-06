using System;

public class ConsolePrinter
{
    private const int MaxCount = 6;

    internal class BooleanPrinter
    {
        public void Print(bool booleanValue)
        {
            string booleanValueAsString = booleanValue.ToString();
            Console.WriteLine(booleanValueAsString);
        }
    }

    public static void Main()
    {
        ConsolePrinter.BooleanPrinter printer = new ConsolePrinter.BooleanPrinter();
        printer.Print(true);
    }
}
