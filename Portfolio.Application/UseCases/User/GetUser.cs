using Portfolio.Application.DTOs.User;
using Portfolio.Domain.Repositories;

namespace Portfolio.Application.UseCases.User
{
    public class GetUser
    {
        private readonly IUserRepository _userRepository;

        public GetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModelOutput> ExecuteAsync(GetUserDTO getUserDTO)
        {
            var user = await _userRepository.GetByIdAsync(getUserDTO.Id);
            return UserModelOutput.FromUser(user);
        }
    }
}
