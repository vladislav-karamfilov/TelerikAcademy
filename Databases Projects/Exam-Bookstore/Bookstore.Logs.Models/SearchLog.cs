namespace Bookstore.Logs.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class SearchLog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string QueryXml { get; set; }
    }
}
