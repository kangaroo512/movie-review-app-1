namespace Movie_Review_API.Repositories
{
    public interface IMovieRepository<TEntity>
    {

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        void Delete(TEntity entity);

        Task Save();
    }
}
