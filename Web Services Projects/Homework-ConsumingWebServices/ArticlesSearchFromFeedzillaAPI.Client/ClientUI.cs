namespace ArticlesSearchFromFeedzillaAPI.Client
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    class ClientUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting the titles and URLs of a specified number of articles from Feedzilla API service***");
            Console.Write(decorationLine);

            Console.Write("Enter the search string: ");
            string searchString = Console.ReadLine();
            Console.Write("Enter the count of articles to retrieve: ");
            int resultsCount = int.Parse(Console.ReadLine());

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/");
            MediaTypeWithQualityHeaderValue jsonMediaType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(jsonMediaType);

            ArticlesCollection articles = new ArticlesCollection();
            using (httpClient)
            {
                articles = GetArticles(httpClient, searchString, resultsCount);
            }

            if (articles.Articles.Count != 0)
            {
                foreach (Article article in articles.Articles)
                {
                    Console.Write(new string('_', Console.WindowWidth));
                    Console.WriteLine("Title: {0}", article.Title);
                    Console.WriteLine("URL: {0}", article.Url);
                }
            }
            else
            {
                Console.WriteLine("No articles found!");
            }
        }

        static ArticlesCollection GetArticles(HttpClient httpClient, string searchString, int resultsCount)
        {
            string searchUrl = string.Format("search.json?q={0}&count={1}", searchString, resultsCount);
            HttpResponseMessage response = httpClient.GetAsync(searchUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                ArticlesCollection articles = response.Content.ReadAsAsync<ArticlesCollection>().Result;
                return articles;
            }
            else
            {
                throw new HttpRequestException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}
