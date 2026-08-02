using System.Data;
using System.Threading.Tasks;
using Dapper;
using ProductApp.Application.Common.Interfaces;
using ProductApp.Domain.Entities;

namespace ProductApp.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public UserRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            using var connection = _connectionFactory.CreateConnection();
            var query = "SELECT PhoneNumber, Name FROM Test_User_tbl WHERE PhoneNumber = @PhoneNumber";
            return await connection.QueryFirstOrDefaultAsync<User>(query, new { PhoneNumber = phoneNumber });
        }
    }
}
