using System;

class HappyTickets
{
    static void Main()
    {
        byte winnerTickets = 0;
        int sum = 0;
        byte number1 = 0;
        ushort number2 = 0;
        do
        {
            string input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            number1 = (byte)((input[0] - '0') * 10 + (input[4] - '0'));
            number2 = (ushort)((input[1] - '0') * 100 + (input[2] - '0') * 10 + (input[3] - '0'));
            if (number2 % number1 == 0)
            {
                sum += (number2 / number1);
                winnerTickets++;
            }
        } while (true);
        Console.WriteLine(sum);
        Console.WriteLine(winnerTickets);
    }
}
