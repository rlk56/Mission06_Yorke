using System.ComponentModel.DataAnnotations;

namespace Mission06_Yorke.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Category { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? Lent_To { get; set; }
        [MaxLength (25)]
        public string? Notes { get; set; }

    }
}
