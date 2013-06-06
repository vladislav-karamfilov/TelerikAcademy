namespace CalendarSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using CalendarSystem.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EventsManagerFastTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            Assert.AreEqual(0, eventsManager.Count);
        }

        #region AddEvent method tests
        [TestMethod]
        public void AddEventWithoutLocationTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent = new Event() { Date = eventDate, Title = "PARTY", Location = null };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);

            Assert.AreEqual(1, eventsManager.Count);
        }

        [TestMethod]
        public void AddEventWithLocationTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date,
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent = new Event() { Date = eventDate, Title = "PARTY", Location = "Everywhere" };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);

            Assert.AreEqual(1, eventsManager.Count);
        }

        [TestMethod]
        public void AddDuplicateTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent =
                new Event() { Date = eventDate, Title = "PARTY", Location = "Everywhere" };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);
            eventsManager.AddEvent(newEvent);

            Assert.AreEqual(2, eventsManager.Count);
        }

        [TestMethod]
        public void AddMultipleDuplicateTest()
        {
            int eventsCount = 4;

            string[] dates = new string[] 
            {
                "2001-01-01T10:30:00", "2001-01-01T11:11:11",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00"
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Test", "Trip"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy", "University", "London"
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < eventsCount; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                dates[i], 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                eventsManager.AddEvent(newEvent);
                eventsManager.AddEvent(newEvent);
            }

            Assert.AreEqual(eventsCount * 2, eventsManager.Count);
        }

        [TestMethod]
        public void AddMultipleEventsTest()
        {
            int eventsCount = 4;

            string[] dates = new string[] 
            {
                "2001-01-01T10:30:00", "2001-01-01T11:11:11",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00"
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Test", "Trip"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy", "University", "London"
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < eventsCount; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                dates[i], 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                eventsManager.AddEvent(newEvent);
            }

            Assert.AreEqual(eventsCount, eventsManager.Count);
        }

        [TestMethod]
        public void AddDuplicateAndNonDuplicateEventsTest()
        {
            int eventsCount = 10;

            string[] dates = new string[] 
            {
                "2001-01-01T10:30:00", "2001-01-01T11:11:11",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00",
                "2001-01-01T21:15:11", "2001-01-01T22:16:00",
                "2001-01-01T21:15:11", "2001-01-01T22:15:00"
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Test", "Trip", "Exam", 
                "Trip", "Party", "Test", "Party", "Exam"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy", "University", "London", "Here",
                "Everywhere", "Telerik Academy", "University", "London", "Here",
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < eventsCount; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                dates[i], 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                if (i % 2 == 0)
                {
                    eventsManager.AddEvent(newEvent);
                    eventsManager.AddEvent(newEvent);
                }
                else
                {
                    eventsManager.AddEvent(newEvent);
                }
            }

            Assert.AreEqual(eventsCount + (eventsCount / 2), eventsManager.Count);
        }

        [TestMethod]
        public void Add50000EventsTest()
        {
            int eventsCount = 50000;

            string[] dates = new string[] 
            {
                "2001-01-01T10:30:00", "2001-01-01T11:11:11",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00",
                "2001-01-01T21:15:11", "2001-01-01T22:16:00",
                "2001-01-01T21:15:11", "2001-01-01T22:15:00"
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Test", "Trip", "Exam", 
                "Trip", "Party", "Test", "Party", "Exam"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy", "University", "London", "Here",
                "Everywhere", "Telerik Academy", "University", "London", "Here",
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < eventsCount; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                dates[i % 10], 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i % 10], Location = locations[i % 10] };
                if (i % 2 == 0)
                {
                    eventsManager.AddEvent(newEvent);
                    eventsManager.AddEvent(newEvent);
                }
                else
                {
                    eventsManager.AddEvent(newEvent);
                }
            }

            Assert.AreEqual(eventsCount + (eventsCount / 2), eventsManager.Count);
        }
        #endregion

        #region DeleteEvents method tests
        [TestMethod]
        public void DeleteMissingEventTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent = new Event() { Date = eventDate, Title = "PARTY", Location = null };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);

            int deletedEventsCount = eventsManager.DeleteEventsByTitle("Missing");
            Assert.AreEqual(0, deletedEventsCount);
        }

        [TestMethod]
        public void DeleteOneEventTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent = new Event() { Date = eventDate, Title = "PARTY", Location = null };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);

            int deletedEventsCount = eventsManager.DeleteEventsByTitle("PARTY");
            Assert.AreEqual(1, deletedEventsCount);
        }

        [TestMethod]
        public void CaseInsensitiveDeleteOneEventTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent = new Event() { Date = eventDate, Title = "PARTY", Location = null };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);

            int deletedEventsCount = eventsManager.DeleteEventsByTitle("PaRty");
            Assert.AreEqual(1, deletedEventsCount);
        }

        [TestMethod]
        public void DeleteMultipleEventsTest()
        {
            string[] dates = new string[] 
            {
                "2001-01-01T10:30:00", "2001-01-01T11:11:11",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00",
                "2001-01-01T21:30:11", "2001-01-01T22:30:00",
                "2001-01-01T21:15:11", "2001-01-01T22:16:00",
                "2001-01-01T21:15:11", "2001-01-01T22:15:00"
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Test", "Trip", "Exam", 
                "Trip", "Party", "Test", "Party", "Exam"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy", "University", "London", "Here",
                "Everywhere", "Telerik Academy", "University", "London", "Here",
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < 10; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                    dates[i], 
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                eventsManager.AddEvent(newEvent);
            }

            int deletedEventsCount = eventsManager.DeleteEventsByTitle("PaRty");
            Assert.AreEqual(3, deletedEventsCount);
        }
        #endregion

        #region ListEvents method tests
        [TestMethod]
        public void ListMissingEventTest()
        {
            string date = "2001-01-01T10:30:00";
            DateTime eventDate = DateTime.ParseExact(
                date, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent = new Event() { Date = eventDate, Title = "PARTY", Location = null };
            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent);

            IEnumerable<Event> matchedEvents = eventsManager.ListEvents(eventDate.AddDays(10), 1);
            string[] matchedEventsStrings = GetTextRepresentations(matchedEvents);

            Assert.AreEqual(0, matchedEvents.Count());
            CollectionAssert.AreEqual(new string[0], matchedEventsStrings);
        }

        [TestMethod]
        public void ListOneEventTest()
        {
            string date1 = "2001-01-01T10:30:00";
            DateTime eventDate1 = DateTime.ParseExact(
                date1, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent1 = new Event() { Date = eventDate1, Title = "PARTY", Location = null };

            string date2 = "2001-01-01T10:30:00";
            DateTime eventDate2 = DateTime.ParseExact(
                date2, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent2 = new Event() { Date = eventDate2, Title = "Trip", Location = "London" };

            string date3 = "2001-01-01T10:30:00";
            DateTime eventDate3 = DateTime.ParseExact(
                date3, 
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);
            Event newEvent3 = new Event() { Date = eventDate3, Title = "Trip", Location = "Moscow" };

            EventsManagerFast eventsManager = new EventsManagerFast();
            eventsManager.AddEvent(newEvent1);
            eventsManager.AddEvent(newEvent2);
            eventsManager.AddEvent(newEvent3);

            IEnumerable<Event> matchedEvents = eventsManager.ListEvents(eventDate1, 1);
            string[] matchedEventsStrings = GetTextRepresentations(matchedEvents);
            string[] expectedEventsStrings = new string[]
            {
                "2001-01-01T10:30:00 | PARTY"
            };

            Assert.AreEqual(1, matchedEvents.Count());
            CollectionAssert.AreEqual(expectedEventsStrings, matchedEventsStrings);
        }

        [TestMethod]
        public void ListLessThanRequiredEventsTest()
        {
            string[] dates = new string[] 
            {
                "2002-01-01T10:30:00", "2011-01-01T22:16:00",
                "2002-01-01T10:30:00", "2011-01-01T22:16:00",
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Trip", "Test"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy",
                "London", "University"
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < 4; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                    dates[i], 
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                eventsManager.AddEvent(newEvent);
            }

            DateTime eventDateToMatch = DateTime.ParseExact(
                    "2011-01-01T22:16:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);
            IEnumerable<Event> matchedEvents = eventsManager.ListEvents(eventDateToMatch, 7);
            string[] matchedEventsStrings = GetTextRepresentations(matchedEvents);
            string[] expectedEventsStrings = new string[]
            {
                "2011-01-01T22:16:00 | Exam | Telerik Academy",
                "2011-01-01T22:16:00 | Test | University",
            };

            Assert.AreEqual(2, matchedEvents.Count());
            CollectionAssert.AreEqual(expectedEventsStrings, matchedEventsStrings);
        }

        [TestMethod]
        public void ListRequiredEventsFromMoreMatchedTest()
        {
            string[] dates = new string[] 
            {
                "2002-01-01T10:30:00", "2011-01-01T22:16:00",
                "2002-01-01T10:30:00", "2011-01-01T22:16:00",
                "2011-01-01T22:16:00", "2011-01-01T22:16:00",
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Trip", "Test", "Tennis", "Ski"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy",
                "London", "University", 
                "Rome", "Alpes"
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < 6; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                    dates[i], 
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                eventsManager.AddEvent(newEvent);
            }

            DateTime eventDateToMatch = DateTime.ParseExact(
                    "2011-01-01T22:16:00", 
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);
            IEnumerable<Event> matchedEvents = eventsManager.ListEvents(eventDateToMatch, 2);
            string[] matchedEventsStrings = GetTextRepresentations(matchedEvents);
            string[] expectedEventsStrings = new string[]
            {
                "2011-01-01T22:16:00 | Exam | Telerik Academy",
                "2011-01-01T22:16:00 | Ski | Alpes"
            };

            Assert.AreEqual(2, matchedEvents.Count());
            CollectionAssert.AreEqual(expectedEventsStrings, matchedEventsStrings);
        }

        [TestMethod]
        public void AlphabeticalOrderOfListedEventsTest()
        {
            string[] dates = new string[] 
            {
                "2002-01-01T10:30:00", "2011-01-01T22:16:00",
                "2002-01-01T10:30:00", "2011-01-01T22:16:00",
                "2011-01-01T22:16:00", "2011-01-01T22:16:00",
            };
            string[] titles = new string[]
            {
                "Party", "Exam", "Trip", "Test", "Tennis", "Ski"
            };
            string[] locations = new string[]
            {
                "Everywhere", "Telerik Academy",
                "London", "University", 
                "Paris", null
            };

            EventsManagerFast eventsManager = new EventsManagerFast();
            for (int i = 0; i < 6; i++)
            {
                DateTime eventDate = DateTime.ParseExact(
                    dates[i], 
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);

                Event newEvent =
                    new Event() { Date = eventDate, Title = titles[i], Location = locations[i] };
                eventsManager.AddEvent(newEvent);
            }

            DateTime eventDateToMatch = DateTime.ParseExact(
                    "2011-01-01T22:16:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture);
            IEnumerable<Event> matchedEvents = eventsManager.ListEvents(eventDateToMatch, 3);
            string[] matchedEventsStrings = GetTextRepresentations(matchedEvents);
            string[] expectedEventsStrings = new string[]
            {
                "2011-01-01T22:16:00 | Exam | Telerik Academy",
                "2011-01-01T22:16:00 | Ski",
                "2011-01-01T22:16:00 | Tennis | Paris",
            };

            Assert.AreEqual(3, matchedEvents.Count());
            CollectionAssert.AreEqual(expectedEventsStrings, matchedEventsStrings);
        }

        private static string[] GetTextRepresentations(IEnumerable<Event> matchedEvents)
        {
            string[] textRepresentations = new string[matchedEvents.Count()];
            int index = 0;
            foreach (Event currentEvent in matchedEvents)
            {
                textRepresentations[index] = currentEvent.ToString();
                index++;
            }

            return textRepresentations;
        }
        #endregion
    }
}
