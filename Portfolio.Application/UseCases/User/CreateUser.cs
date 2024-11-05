using UserEntity = Portfolio.Domain.Entities;
using Portfolio.Domain.ValueObjects;
using Portfolio.Application.DTOs.User;
using Portfolio.Domain.Repositories;
using Portfolio.Application.Interfaces.User;

namespace Portfolio.Application.UseCases.User
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModelOutput> Handle(CreateUserDTO createUserDTO, CancellationToken cancellationToken)
        {
            var user = new UserEntity.User
            {
                Id = Guid.NewGuid(),
                Name = new FullName(createUserDTO.FirstName, createUserDTO.LastName),
                Email = createUserDTO.Email,
                Bio = createUserDTO.Bio
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return UserModelOutput.FromUser(user);
        }
    }
}
