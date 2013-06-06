using System;
using System.Diagnostics;

class TheTypeMaster
{
    static void Main()
    {
        string upperLines = "===============================";
        string welcome = "  Welcome to The Type Master!  ";
        string lowerLines = "===============================";
        Console.WriteLine("{0, 55}", upperLines);
        Console.WriteLine("{0, 55}", welcome);
        Console.WriteLine("{0, 55}", lowerLines);
        Console.WriteLine("\tYou think you're the fastest typewriter? Let's put that on test!\r\n");
        Console.WriteLine("    You will see a sentence. Read it, then start typing as fast as you can. Your goal is to retype the same sentence including capital letters and punctuation marks. As soon as you finish, press Enter again to see the results.\r\n");
        Console.WriteLine("  To begin, press Enter...");
        Console.ReadLine();
        string firstSentence = "The big woolly mammoth slipped and fell down the hill where crushed into a tree near the long river.";
        Console.WriteLine(firstSentence);

        ConsoleKeyInfo again;
        byte gameNumber = 1;
        do
        {
            Console.WriteLine("\r\nWhen you're ready, press Enter and start typing...");
            Console.ReadLine();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            string userType = Console.ReadLine();
            timer.Stop();
            object userTime = timer.Elapsed;

            Console.WriteLine();
            if (userType == firstSentence)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game# {0}. Well done! You retyped exactly the same sentence.", gameNumber);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your time is: {0}", userTime);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game# {0}. Sorry, but you didn't retype exactly the same sentence.", gameNumber);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your time is: {0}\r\n", userTime);
                Console.ResetColor();
            }

            gameNumber++;
            Console.Write("Wanna try again? (y/n)");
            again = Console.ReadKey();
        }
        while (again.KeyChar == 'y');
    }
}