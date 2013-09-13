using System;
using io.iron.ironmq;

public class MessageSender
{
    internal static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Simple chat application (sender)***");
        Console.Write(decorationLine);

        Client client = new Client("520f706527c7200005000001", "JySHBhogfvbKpQ8I5CkUFoY-FnI");

        Queue queue = client.queue("ChatQueue");

        Console.WriteLine("You can start entering messages");

        while (true)
        {
            string message = Console.ReadLine();
            queue.push(message);
            Console.WriteLine("Message sent to IronMQ server.");
        }
    }
}
