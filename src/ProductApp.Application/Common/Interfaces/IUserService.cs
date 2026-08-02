using System.Threading.Tasks;
using ProductApp.Application.Common.Dtos;

namespace ProductApp.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> LoginAsync(string phoneNumber);
    }
}
