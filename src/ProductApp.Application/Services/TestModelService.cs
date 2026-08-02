using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Application.Common.Dtos;
using ProductApp.Application.Common.Interfaces;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Services
{
    public class TestModelService : ITestModelService
    {
        private readonly ITestModelRepository _repository;

        public TestModelService(ITestModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<TestModelDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return MapToDto(entity);
        }

        public async Task<IEnumerable<TestModelDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<TestModelDto> CreateAsync(CreateTestModelDto dto)
        {
            var entity = new TestModel
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };

            var generatedId = await _repository.AddAsync(entity);
            entity.Id = generatedId;

            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTestModelDto dto)
        {
            var entity = new TestModel
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };

            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private static TestModelDto MapToDto(TestModel entity)
        {
            return new TestModelDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Stock = entity.Stock,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate
            };
        }
    }
}
