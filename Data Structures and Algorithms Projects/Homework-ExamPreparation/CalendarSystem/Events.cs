using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

public class CalendarSystemDemo
{
    internal static void Main()
    {
        CommandProcessor commandProcessor = new CommandProcessor(new EventsManagerFast());
        StringBuilder output = new StringBuilder();
        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "End")
            {
                break;
            }

            Command parsedCommand = Command.Parse(inputLine);
            string commandOutput = commandProcessor.ProcessCommand(parsedCommand);
            output.AppendLine(commandOutput);
        }

        Console.Write(output);
    }
}

public struct Command
{
    private const char CommandNameSeparator = ' ';
    private const char CommandArgumentsSeparators = '|';

    public string Name { get; set; }

    public string[] Arguments { get; set; }

    public static Command Parse(string inputCommand)
    {
        int nameEndIndex = inputCommand.IndexOf(CommandNameSeparator);
        string[] commandArguments = inputCommand.Substring(nameEndIndex + 1).Split(CommandArgumentsSeparators);
        TrimArguments(commandArguments);

        Command command = new Command();
        command.Name = inputCommand.Substring(0, nameEndIndex);
        command.Arguments = commandArguments;
        return command;
    }

    private static void TrimArguments(string[] arguments)
    {
        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = arguments[i].Trim();
        }
    }
}

public class CommandProcessor
{
    private const string AddEventCommandName = "AddEvent";
    private const string DeleteEventsCommandName = "DeleteEvents";
    private const string ListEventsCommandName = "ListEvents";
    private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
    private const string NoEventsFoundMessage = "No events found";
    private const string DeletedEventsMessage = " events deleted";
    private const string EventAddedMessage = "Event added";

    private readonly EventsManagerFast eventsManager;

    public CommandProcessor(EventsManagerFast eventsManager)
    {
        this.eventsManager = eventsManager;
    }

    public EventsManagerFast EventsProcessor
    {
        get
        {
            return this.eventsManager;
        }
    }

    public string ProcessCommand(Command command)
    {
        switch (command.Name)
        {
            case AddEventCommandName:
                return this.ProcessAddCommand(command);

            case DeleteEventsCommandName:
                return this.ProcessDeleteCommand(command);

            case ListEventsCommandName:
                return this.ProcessListEventsCommand(command);

            default:
                throw new ArgumentException(
                    string.Format("Invalid input command: {0}!", command.Name),
                    "inputCommand");
        }
    }

    private string ProcessListEventsCommand(Command command)
    {
        DateTime eventDate = DateTime.ParseExact(
            command.Arguments[0],
            DateTimeFormat,
            CultureInfo.InvariantCulture);
        int numberOfElementsToList = int.Parse(command.Arguments[1]);

        IEnumerable<Event> events = this.eventsManager.ListEvents(eventDate, numberOfElementsToList);
        if (events.Count() != 0)
        {
            StringBuilder output = new StringBuilder();
            foreach (Event currentEvent in events)
            {
                output.AppendLine(currentEvent.ToString());
            }

            return output.ToString().Trim();
        }
        else
        {
            return NoEventsFoundMessage;
        }
    }

    private string ProcessDeleteCommand(Command command)
    {
        int deletedEventsCount = this.eventsManager.DeleteEventsByTitle(command.Arguments[0]);

        if (deletedEventsCount == 0)
        {
            return NoEventsFoundMessage;
        }
        else
        {
            return deletedEventsCount + DeletedEventsMessage;
        }
    }

    private string ProcessAddCommand(Command command)
    {
        DateTime eventDate = DateTime.ParseExact(
            command.Arguments[0],
            DateTimeFormat,
            CultureInfo.InvariantCulture);
        Event newEvent = new Event();
        newEvent.Date = eventDate;
        newEvent.Title = command.Arguments[1];

        if (command.Arguments.Length == 3)
        {
            newEvent.Location = command.Arguments[2];
        }
        else
        {
            newEvent.Location = null;
        }

        this.eventsManager.AddEvent(newEvent);

        return EventAddedMessage;
    }
}

public class Event : IComparable<Event>
{
    public DateTime Date { get; set; }

    public string Title { get; set; }

    public string Location { get; set; }

     public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        output.AppendFormat("{0:yyyy-MM-ddTHH:mm:ss} | {1}", this.Date, this.Title);

        if (this.Location != null)
        {
            output.AppendFormat(" | {0}", this.Location);
        }

        return output.ToString();
    }

    public int CompareTo(Event otherEvent)
    {
        int comparedDatesResult = DateTime.Compare(this.Date, otherEvent.Date);
        if (comparedDatesResult != 0)
        {
            return comparedDatesResult;
        }

        int comparedTitlesResult =
            string.Compare(this.Title, otherEvent.Title, StringComparison.InvariantCulture);
        if (comparedTitlesResult != 0)
        {
            return comparedTitlesResult;
        }

        int comparedLocationsResult =
            string.Compare(this.Location, otherEvent.Location, StringComparison.InvariantCulture);
        return comparedLocationsResult;
    }
}

public class EventsManagerFast
{
    private const bool AllowDuplicates = true;

    private readonly MultiDictionary<string, Event> byTitles =
        new MultiDictionary<string, Event>(AllowDuplicates);
    private readonly OrderedMultiDictionary<DateTime, Event> byDates =
        new OrderedMultiDictionary<DateTime, Event>(AllowDuplicates);

    public void AddEvent(Event newEvent)
    {
        string eventTitleLowerCase = newEvent.Title.ToLowerInvariant();
        this.byTitles.Add(eventTitleLowerCase, newEvent);
        this.byDates.Add(newEvent.Date, newEvent);
    }

    public int DeleteEventsByTitle(string title)
    {
        string titleLowerCase = title.ToLowerInvariant();
        ICollection<Event> eventsToDelete = this.byTitles[titleLowerCase];
        int numberOfElementsToDelete = eventsToDelete.Count;

        foreach (Event currentEvent in eventsToDelete)
        {
            this.byDates.Remove(currentEvent.Date, currentEvent);
        }

        this.byTitles.Remove(titleLowerCase);

        return numberOfElementsToDelete;
    }

    public IEnumerable<Event> ListEvents(DateTime date, int numberOfEventsToList)
    {
        var matchedEvents =
            from currentEvent in this.byDates.RangeFrom(date, true).Values
            select currentEvent;

        IEnumerable<Event> events = matchedEvents.Take(numberOfEventsToList);
        return events;
    }
}