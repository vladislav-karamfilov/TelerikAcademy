namespace CalendarSystem.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsManagerNormal : IEventsManager
    {
        private readonly List<Event> list = new List<Event>();

        public void AddEvent(Event newEvent)
        {
            this.list.Add(newEvent);
        }

        // BOTTLENECK: Operation deleting from a List<T> is a slow operation
        // because the elements from right of the element to be deleted must
        // be moved by a position to left
        // FIX: No fix of this bottleneck is available except 
        // changing the data structure holding the events to a hash table
        public int DeleteEventsByTitle(string title)
        {
            string titleLowerCase = title.ToLowerInvariant();
            int deletedEventsCount = this.list.RemoveAll(
                e => e.Title.ToLowerInvariant() == titleLowerCase);

            return deletedEventsCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int numberOfElementsToList)
        {
            var matchedEvents =
                from currentEvent in this.list
                where currentEvent.Date >= date
                orderby currentEvent.Date, currentEvent.Title, currentEvent.Location
                select currentEvent;
            IEnumerable<Event> matchedEventsByCount = matchedEvents.Take(numberOfElementsToList);

            return matchedEventsByCount;
        }
    }
}
