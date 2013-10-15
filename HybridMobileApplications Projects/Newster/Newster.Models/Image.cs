namespace Newster.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        [Key, Column("ImageID")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; }

        public int NewsArticleID { get; set; }

        [ForeignKey("NewsArticleID")]
        public virtual NewsArticle NewsArticle { get; set; }
    }
}
