using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Common.Interfaces
{
    public interface ITestModelRepository
    {
        Task<TestModel?> GetByIdAsync(int id);
        Task<IEnumerable<TestModel>> GetAllAsync();
        Task<int> AddAsync(TestModel entity);
        Task<bool> UpdateAsync(TestModel entity);
        Task<bool> DeleteAsync(int id);
    }
}
