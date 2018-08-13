namespace Tests
{
    using System.Collections.Generic;
    using System.Data;
    using Database.Infrastracture;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.Sqlite;

    public class InMemoryDatabase: IDatabaseConnectionFactory
    {
        private readonly OrmLiteConnectionFactory dbFactory =
            new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection GetConnection() => dbFactory.OpenDbConnection();

        public void Insert<T>(IEnumerable<T> items)
        {
            using (var db = GetConnection())
            {
                db.CreateTableIfNotExists<T>();
                foreach (var item in items)
                {
                    db.Insert(item);
                }
            }
        }
    }
}
