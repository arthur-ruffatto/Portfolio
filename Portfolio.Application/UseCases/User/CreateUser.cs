using UserEntity = Portfolio.Domain.Entities;
using Portfolio.Domain.ValueObjects;
using Portfolio.Application.DTOs.User;
using Portfolio.Domain.Repositories;


namespace Portfolio.Application.UseCases.User
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModelOutput> ExecuteAsync(CreateUserDTO createUserDTO)
        {
            var user = new UserEntity.User
            {
                Id = Guid.NewGuid(),
                Name = new FullName(createUserDTO.FirstName, createUserDTO.LastName),
                Email = createUserDTO.Email,
                Bio = createUserDTO.Bio
            };

            await _userRepository.AddAsync(user);

            return UserModelOutput.FromUser(user);
        }
    }
}
