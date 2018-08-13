namespace Database.Repositories
{
    using Entities;
    using Infrastracture;
    using Interfaces;

    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
