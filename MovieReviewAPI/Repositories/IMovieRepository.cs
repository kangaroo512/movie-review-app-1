namespace Movie_Review_API.Repositories
{
    public interface IMovieRepository<TEntity>
    {

        public Task<IEnumerable<TEntity>> Get();

        public Task<TEntity> GetById(int id);

        public Task Add(TEntity entity);

        public Task Update(TEntity entity);

        public void Delete(TEntity entity);

        public Task Save();
    }
}
