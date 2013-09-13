namespace ArticlesSearchFromFeedzillaAPI.Client
{
    using System;
    using System.Collections.Generic;
    
    public class ArticlesCollection
    {
        public ArticlesCollection()
        {
            this.Articles = new List<Article>();
        }

        public ICollection<Article> Articles { get; set; }

        public string Description { get; set; }

        public string SyndicationUrl { get; set; }

        public string Title { get; set; }
    }
}
