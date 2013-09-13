namespace TelerikAcademyForum.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Vote
    {
        [Key]
        public int ID { get; set; }

        public int Value { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int? PostID { get; set; }

        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }
    }
}
