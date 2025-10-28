using Movie_Review_API.DTOs.Movies;

namespace Movie_Review_API.Services.Movies
{
    public interface IMovieService
    {

        Task<IEnumerable<MovieGetDTO>> Get();
        Task<MovieGetDTO> GetById(int id);
        Task<MovieGetDTO> Add(MovieInsertDTO movieInsertDTO);
        Task<MovieGetDTO> Update(int id, MovieUpdateDTO movieUpdateDTO);

        Task<MovieGetDTO> Delete(int id);
    }
}
