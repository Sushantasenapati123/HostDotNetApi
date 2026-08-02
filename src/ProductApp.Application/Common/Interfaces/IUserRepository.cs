using System.Threading.Tasks;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
    }
}
