namespace CalendarSystem.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private const bool AllowDuplicates = true;
        private readonly MultiDictionary<string, Event> titles = 
            new MultiDictionary<string, Event>(AllowDuplicates);

        private readonly OrderedMultiDictionary<DateTime, Event> dates = 
            new OrderedMultiDictionary<DateTime, Event>(AllowDuplicates);

        public int Count
        {
            get
            {
                return this.dates.KeyValuePairs.Count;
            }
        }

        public void AddEvent(Event newEvent)
        {
            string eventTitleLowerCase = newEvent.Title.ToLowerInvariant();
            this.titles.Add(eventTitleLowerCase, newEvent);

            this.dates.Add(newEvent.Date, newEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleLowerCase = title.ToLowerInvariant();
            ICollection<Event> eventsToDelete = this.titles[titleLowerCase];
            int numberOfElementsToDelete = eventsToDelete.Count;

            foreach (Event currentEvent in eventsToDelete)
            {
                this.dates.Remove(currentEvent.Date, currentEvent);
            }

            this.titles.Remove(titleLowerCase);

            return numberOfElementsToDelete;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int numberOfEventsToList)
        {
            var matchedEvents =
                from currentEvent in this.dates.RangeFrom(date, true).Values
                select currentEvent;
            
            IEnumerable<Event> events = matchedEvents.Take(numberOfEventsToList);
            return events;
        }
    }
}
