using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Review_API.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public string Director {  get; set; }

        public int DurationMinutes { get; set; }

        public MovieRating Rating {  get; set; }


    }
}
