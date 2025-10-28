using Movie_Review_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Review_API.DTOs.Reviews
{
    public class ReviewInsertDTO
    {
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        public string AuthorName { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
