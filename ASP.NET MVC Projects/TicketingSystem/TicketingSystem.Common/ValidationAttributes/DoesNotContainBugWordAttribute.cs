namespace TicketingSystem.Common.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;

    public class DoesNotContainBugWordAttribute : ValidationAttribute
    {
        private const string BugWord = "bug";

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            return !valueAsString.ToLower().Contains(BugWord);
        }
    }
}
