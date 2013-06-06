namespace CalendarSystem.Common
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        /// <summary>
        /// Adds a new event to IEventsManager instance's collection of events.
        /// </summary>
        /// <remarks>
        /// Duplicate elements are allowed to be added.
        /// </remarks>
        /// <param name="newEvent">The new event to be added.</param>
        void AddEvent(Event newEvent);

        /// <summary>
        /// Deletes the events that has the provided title from IEventsManager instance's collection of events.
        /// </summary>
        /// <remarks>
        /// The performed deleting uses case insensitive search of title.
        /// </remarks>
        /// <param name="title">The title of the event to be deleted.</param>
        /// <returns>
        /// The count of events that has been deleted from IEventsManager instance's collection of events.
        /// </returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Lists the specified by <paramref name="numberOfEventsToList"/> events 
        /// from IEventsManager instance's collection of events that have date specified by <paramref name="date"/>.
        /// </summary>
        /// <remarks>
        /// If the matched elements according to <paramref name="date"/> are more than 
        /// <paramref name="numberOfEventsToList"/> by count, only <paramref name="numberOfEventsToList"/> are
        /// listed. If the matched elements according to <paramref name="date"/> are less than 
        /// <paramref name="numberOfEventsToList"/> by count, only the matched elements are listed
        /// </remarks>
        /// <param name="date">The date of the events to be listed.</param>
        /// <param name="numberOfEventsToList">The number of elements to list.</param>
        /// <returns>
        /// An enumerable collection of <paramref name="numberOfEventsToList"/> events
        /// that have date specified by <paramref name="date"/>.</returns>
        IEnumerable<Event> ListEvents(DateTime date, int numberOfEventsToList);
    }
}
