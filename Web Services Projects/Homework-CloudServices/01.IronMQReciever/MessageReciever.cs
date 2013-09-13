using System;
using io.iron.ironmq;
using io.iron.ironmq.Data;
using System.Threading;

public class MessageReciever
{
    internal static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Simple chat application (receiver)***");
        Console.Write(decorationLine);

        Client client = new Client("520f706527c7200005000001", "JySHBhogfvbKpQ8I5CkUFoY-FnI");
        Queue queue = client.queue("ChatQueue");
        Console.WriteLine("Listening for new messages from IronMQ server");
        while (true)
        {
            Message message = queue.get();
            if (message != null)
            {
                Console.WriteLine(message.Body);
                queue.deleteMessage(message);
            }

            Thread.Sleep(100);
        }
    }
}
