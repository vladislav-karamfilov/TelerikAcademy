namespace CalendarSystem.UI
{
    using System;
    using CalendarSystem.Common;

    public class CalendarSystemDemo
    {
        internal static void Main()
        {
            IEventsManager eventsManager = new EventsManagerFast();
            CommandProcessor commandProcessor = new CommandProcessor(eventsManager);

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                try
                {
                    Command parsedCommand = Command.Parse(inputLine);
                    string commandOutput = commandProcessor.ProcessCommand(parsedCommand);
                    Console.WriteLine(commandOutput);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            }
        }    
    }
}
