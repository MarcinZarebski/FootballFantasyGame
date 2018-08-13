namespace Database.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        void Delete(TEntity entity);
    }
}
