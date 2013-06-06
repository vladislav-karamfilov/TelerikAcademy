namespace CalendarSystem.Common
{
    using System;
    using System.Text;

    public class Event : IComparable<Event>
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        // BOTTLENECK: Creates a large number of strings
        // FIX: Use StringBuilder
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
}
