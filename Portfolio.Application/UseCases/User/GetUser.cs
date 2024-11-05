using Portfolio.Application.DTOs.User;
using Portfolio.Application.Interfaces.User;
using Portfolio.Domain.Repositories;

namespace Portfolio.Application.UseCases.User
{
    public class GetUser : IGetUser
    {
        private readonly IUserRepository _userRepository;

        public GetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModelOutput> Handle(GetUserDTO getUserDTO, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(getUserDTO.Id);
            return UserModelOutput.FromUser(user);
        }
    }
}
