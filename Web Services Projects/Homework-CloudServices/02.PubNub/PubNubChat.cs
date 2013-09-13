using System;
using System.Collections.Generic;
using System.Diagnostics;
using _02.PubNub;
using System.Threading;
using System.Threading.Tasks;

class PubNubChat
{
    static void Main(string[] args)
    {
		string decorationLine = new string('-', Console.WindowWidth);
		Console.Write(decorationLine);
		Console.WriteLine("***PubNub simple chat application***");
		Console.Write(decorationLine);
	
        Process.Start("..\\..\\RecieverPage.html");

        Thread.Sleep(2000);

        PubnubAPI pubnub = new PubnubAPI(
            "pub-c-d9aadadf-abba-443c-a767-62023d43411a",               // PUBLISH_KEY
            "sub-c-102d0358-073f-11e3-916b-02ee2ddab7fe",               // SUBSCRIBE_KEY
            "sec-c-YmI4NDcxNzQtOWZhYi00MTRmLWI4ODktMDI2ZjViMjQyYzdj",   // SECRET_KEY
            false                                                       // SSL_ON/OFF
        );

        string channel = "PublishApp";

        // Publish a sample message to Pubnub
        List<object> publishResult = pubnub.Publish(channel, "Hello PubNub!");
        Console.WriteLine(
            "Publish Success: " + publishResult[0].ToString() + "\n" +
            "Publish Info: " + publishResult[1]
        );

        // Show PubNub server time
        object serverTime = pubnub.Time();
        Console.WriteLine("Server Time: " + serverTime.ToString());

        // Subscribe for receiving messages (in a background task to avoid blocking)
        Task task = new Task(
            () =>
            pubnub.Subscribe(
                channel,
                delegate(object message)
                {
                    Console.WriteLine("Received Message -> '" + message + "'");
                    return true;
                }
            )
        );

        task.Start();

        // Read messages from the console and publish them to PubNub
        while (true)
        {
            Console.Write("Enter a message to be sent to Pubnub: ");
            string msg = Console.ReadLine();
            pubnub.Publish(channel, msg);
            Console.WriteLine("Message {0} sent.", msg);
        }
    }
}
