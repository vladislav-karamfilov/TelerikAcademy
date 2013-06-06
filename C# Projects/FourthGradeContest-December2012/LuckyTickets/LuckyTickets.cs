using System;

class LuckyTickets
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number1 = (input[0] - '0') * 10 + (input[4] - '0');
        int number2 = (input[1] - '0') * 100 + (input[2] - '0') * 10 + (input[3] - '0');
        if (number2 != 0 && number2 % number1 == 0)
        {
            Console.WriteLine("Yes");
            Console.WriteLine(number2 / number1);
        }
        else
        {
            Console.WriteLine("Sorry");
        }
    }
}
