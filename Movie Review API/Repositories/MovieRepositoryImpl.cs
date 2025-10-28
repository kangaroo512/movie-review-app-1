using Microsoft.EntityFrameworkCore;
using Movie_Review_API.Data;
using Movie_Review_API.Models;

namespace Movie_Review_API.Repositories
{
    public class MovieRepositoryImpl : IMovieRepository<Movie>
    {

        private AppDbContext _context;

        public MovieRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        async Task IMovieRepository<Movie>.Add(Movie entity) => 
            await _context.Movies.AddAsync(entity);

        void Delete(Movie movie) =>
            _context.Movies.Remove(movie);

        async Task<IEnumerable<Movie>> IMovieRepository<Movie>.Get() =>
            await _context.Movies.ToListAsync();

        async Task<Movie> IMovieRepository<Movie>.GetById(int id) =>
            await _context.Movies.FindAsync(id);

        async Task IMovieRepository<Movie>.Save()
        {
            await _context.SaveChangesAsync();
        }

        async Task IMovieRepository<Movie>.Update(Movie entity)
        {
            _context.Movies.Attach(entity);
            _context.Movies.Entry(entity).State = EntityState.Modified;
        }
    }
}
