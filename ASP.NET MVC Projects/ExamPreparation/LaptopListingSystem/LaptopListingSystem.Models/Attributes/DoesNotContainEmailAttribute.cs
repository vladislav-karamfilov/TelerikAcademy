namespace LaptopListingSystem.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class DoesNotContainEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            return !Regex.IsMatch(valueAsString, GlobalConstants.EmailRegEx);
        }
    }
}
