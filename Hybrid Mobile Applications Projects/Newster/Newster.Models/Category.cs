namespace Newster.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<NewsArticle> newsArticles;

        public Category()
        {
            this.newsArticles = new HashSet<NewsArticle>();
        }

        [Key, Column("CategoryID")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Name { get; set; }

        public virtual ICollection<NewsArticle> NewsArticles
        {
            get { return this.newsArticles; }
            set { this.newsArticles = value; }
        }
    }
}
