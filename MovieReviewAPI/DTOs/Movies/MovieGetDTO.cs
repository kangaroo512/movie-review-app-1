using Movie_Review_API.Models;

namespace Movie_Review_API.DTOs.Movies
{
    public class MovieGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public string Director { get; set; }

        public int DurationMinutes { get; set; }

        public MovieRating Rating { get; set; }
    }
}
