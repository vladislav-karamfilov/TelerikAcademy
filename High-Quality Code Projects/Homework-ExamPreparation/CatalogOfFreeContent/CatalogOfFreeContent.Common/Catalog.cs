namespace CatalogOfFreeContent.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> urls;
        private readonly OrderedMultiDictionary<string, IContent> titles;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.titles = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.urls = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public int ContentItemsCount
        {
            get
            {
                return this.urls.KeyValuePairs.Count;
            }
        }

        public void Add(IContent content)
        {
            this.titles.Add(content.Title, content);
            this.urls.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfElementsToList)
        {
            IEnumerable<IContent> contentToList = 
                from currentTitle in this.titles[title] 
                select currentTitle;

            return contentToList.Take(numberOfElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            IList<IContent> matchedElements = this.urls[oldUrl].ToList();
            foreach (ContentItem content in matchedElements)
            {
                content.Url = newUrl;
            }

            this.urls.Remove(oldUrl);
            this.urls.AddMany(newUrl, matchedElements);
        
            return matchedElements.Count;
        }
    }
}
