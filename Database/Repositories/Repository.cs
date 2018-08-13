namespace Database.Repositories
{
    using Dapper.Contrib.Extensions;
    using Infrastracture;
    using Interfaces;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly IDatabaseConnectionFactory ConnectionFactory;

        public Repository(IDatabaseConnectionFactory connectionFactory)
        {
            this.ConnectionFactory = connectionFactory;
        }

        public TEntity GetById(object id)
        {
            return ConnectionFactory.GetConnection().Get<TEntity>(id);
        }

        public void Insert(TEntity entity)
        {
            ConnectionFactory.GetConnection().Insert(entity);
        }

        public void Update(TEntity entity)
        {
            ConnectionFactory.GetConnection().Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            ConnectionFactory.GetConnection().Delete(entity);
        }
    }
}