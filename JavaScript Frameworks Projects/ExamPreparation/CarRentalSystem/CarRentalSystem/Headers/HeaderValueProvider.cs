namespace CarRentalSystem.Headers
{
    using System.Globalization;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Web.Http.ValueProviders;

    public class HeaderValueProvider<T> : IValueProvider where T : class
    {
        private const string HeaderPrefix = "X-";
        private readonly HttpRequestHeaders headers;

        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            this.headers = headers;
        }

        public bool ContainsPrefix(string prefix)
        {
            var contains = this.headers.Any(h => h.Key.Contains(HeaderPrefix + prefix));
            return contains;
        }

        public ValueProviderResult GetValue(string key)
        {
            var contains = this.headers.Any(h => h.Key.Contains(HeaderPrefix + key));
            if (!contains)
            {
                return null;
            }

            var value = this.headers.GetValues(HeaderPrefix + key).First();
            return new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
        }
    }
}