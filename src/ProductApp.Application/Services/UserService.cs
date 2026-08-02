using System.Threading.Tasks;
using ProductApp.Application.Common.Dtos;
using ProductApp.Application.Common.Interfaces;

namespace ProductApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> LoginAsync(string phoneNumber)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(phoneNumber);
            if (user == null) return null;

            return new UserDto
            {
                PhoneNumber = user.PhoneNumber,
                Name = user.Name
            };
        }
    }
}
