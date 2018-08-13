namespace Database.Infrastracture
{
    using System.Data;
    using System.Data.SqlClient;

    public class RealDatabase : IDatabaseConnectionFactory
    {
        private readonly string connectionString;

        public RealDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
