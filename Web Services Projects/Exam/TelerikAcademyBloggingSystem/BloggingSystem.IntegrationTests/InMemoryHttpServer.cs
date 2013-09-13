namespace BloggingSystem.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal class InMemoryHttpServer
    {
        private readonly HttpClient client;
        private readonly string baseUrl;
        private readonly IEnumerable<Route> routes;

        public InMemoryHttpServer(string baseUrl)
            : this(baseUrl, new List<Route>())
        {
        }

        public InMemoryHttpServer(string baseUrl, IEnumerable<Route> routes)
        {
            this.routes = routes;
            this.baseUrl = baseUrl;

            var config = new HttpConfiguration();
            this.AddHttpRoutes(config.Routes);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var server = new HttpServer(config);
            this.client = new HttpClient(server);
        }

        public HttpResponseMessage Get(
            string requestUrl,
            IDictionary<string, string> headers = null,
            string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        public HttpResponseMessage Post(
            string requestUrl,
            object data,
            IDictionary<string, string> headers = null,
            string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        public HttpResponseMessage Put(
            string requestUrl,
            object data = null,
            IDictionary<string, string> headers = null,
            string mediaType = "application/json")
        {
            var url = requestUrl;
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl + url);
            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            }

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Put;

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = this.client.SendAsync(request).Result;
            return response;
        }

        private void AddHttpRoutes(HttpRouteCollection routeCollection)
        {
            foreach (var route in this.routes)
            {
                routeCollection.MapHttpRoute(route.Name, route.Template, route.Defaults);
            }
        }
    }
}