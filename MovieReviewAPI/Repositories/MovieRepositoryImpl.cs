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
        public async Task Add(Movie entity) => 
            await _context.Movies.AddAsync(entity);

        public void Delete(Movie movie) =>
            _context.Movies.Remove(movie);

        public async Task<IEnumerable<Movie>> Get() =>
            await _context.Movies.ToListAsync();

        public async Task<Movie> GetById(int id) =>
            await _context.Movies.FindAsync(id);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Movie entity)
        {
            _context.Movies.Attach(entity);
            _context.Movies.Entry(entity).State = EntityState.Modified;
        }
    }
}
