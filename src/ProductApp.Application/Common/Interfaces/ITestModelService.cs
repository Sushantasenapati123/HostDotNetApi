using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.Application.Common.Dtos;

namespace ProductApp.Application.Common.Interfaces
{
    public interface ITestModelService
    {
        Task<TestModelDto?> GetByIdAsync(int id);
        Task<IEnumerable<TestModelDto>> GetAllAsync();
        Task<TestModelDto> CreateAsync(CreateTestModelDto dto);
        Task<bool> UpdateAsync(int id, UpdateTestModelDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
