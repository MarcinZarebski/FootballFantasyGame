namespace Database.Infrastracture
{
    using System.Data;

    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
