using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Yorke.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, int.MaxValue)]
        public int Year { get; set; } = 1888;
        public string? Director { get; set; }
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Please choose whether the movie has been edited")]
        public bool Edited { get; set; } = true;
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Please choose whether the movie has been copied to Plex")]
        public bool CopiedToPlex { get; set; } = true;
        [MaxLength (25)]
        public string? Notes { get; set; }

    }
}
