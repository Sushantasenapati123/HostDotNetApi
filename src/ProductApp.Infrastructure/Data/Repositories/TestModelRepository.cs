using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using ProductApp.Application.Common.Interfaces;
using ProductApp.Domain.Entities;

namespace ProductApp.Infrastructure.Data.Repositories
{
    public class TestModelRepository : ITestModelRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public TestModelRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<TestModel?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET");
            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<TestModel>(
                "USP_Test_tbl",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TestModel>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GETALL");

            return await connection.QueryAsync<TestModel>(
                "USP_Test_tbl",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(TestModel entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "INSERT");
            parameters.Add("@Name", entity.Name);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@Price", entity.Price);
            parameters.Add("@Stock", entity.Stock);

            return await connection.ExecuteScalarAsync<int>(
                "USP_Test_tbl",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(TestModel entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "UPDATE");
            parameters.Add("@Id", entity.Id);
            parameters.Add("@Name", entity.Name);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@Price", entity.Price);
            parameters.Add("@Stock", entity.Stock);

            var result = await connection.QueryFirstOrDefaultAsync<TestModel>(
                "USP_Test_tbl",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "DELETE");
            parameters.Add("@Id", id);

            var rowsAffected = await connection.ExecuteScalarAsync<int>(
                "USP_Test_tbl",
                parameters,
                commandType: CommandType.StoredProcedure);

            return rowsAffected > 0;
        }
    }
}
