namespace CalendarSystem.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandProcessor
    {
        private const string AddEventCommandName = "AddEvent";
        private const string DeleteEventsCommandName = "DeleteEvents";
        private const string ListEventsCommandName = "ListEvents";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private const string NoEventsFoundMessage = "No events found";
        private const string DeletedEventsMessage = " events deleted";
        private const string EventAddedMessage = "Event added";

        private readonly IEventsManager eventsManager;

        public CommandProcessor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsProcessor
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
                    if (command.Arguments.Length < 2 || command.Arguments.Length > 3)
                    {
                        throw new ArgumentException(
                            "'AddEvent' command has invalid number of arguments! " +
                            "Only two or three arguments can be passed!");
                    }

                    return this.ProcessAddCommand(command);

                case DeleteEventsCommandName:
                    if (command.Arguments.Length != 1)
                    {
                        throw new ArgumentException(
                            "'DeleteEvents' command has invalid number of arguments! " +
                            "Only one argument can be passed!");
                    }

                    return this.ProcessDeleteCommand(command);

                case ListEventsCommandName:
                    if (command.Arguments.Length != 2)
                    {
                        throw new ArgumentException(
                            "'ListEvents' command has invalid number of arguments! " +
                            "Only two arguments can be passed!");
                    }

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

            // BOTTLENECK: Converting an IEnumerable<T> collection to List collection can be slow
            // when the elements in the IEnumerable<T> collection are not stored 
            // in a collection that implements IList<T>.
            // FIX: In this case no convertion is neeed because IEnumrabl<T> collection can be
            // traversed with a foreach loop.
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
}
