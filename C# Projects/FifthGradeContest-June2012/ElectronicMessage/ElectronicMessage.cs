using System;
// Doesn't work correctly...
class ElectronicMessage
{
    static void Main()
    {
        string message = Console.ReadLine();
        int bestLength = 0;
        int counter = 0;
        int count = 0;
        bool flag = false;
        foreach (char symbol in message)
        {
            if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9'))
            {
                count = 0;
            }
            else if (symbol != ' ' && symbol != '.')
            {
                count++;
                flag = true;
                if (count > bestLength)
                {
                    bestLength = count;
                }
            }
            if ((symbol == ' ' || symbol == '.') && flag)
            {
                counter++;
                count = 0;
                flag = false;
            }
        }
        Console.WriteLine(counter + " " + bestLength);
    }
}
