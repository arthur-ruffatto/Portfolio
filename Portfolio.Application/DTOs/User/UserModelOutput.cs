using UserEntity = Portfolio.Domain.Entities;

namespace Portfolio.Application.DTOs.User
{
    public class UserModelOutput
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public static UserModelOutput FromUser(UserEntity.User user)
        {
            return new UserModelOutput
            {
                Id = user.Id,
                FirstName = user.Name.FirstName,
                LastName = user.Name.LastName,
                Email = user.Email,
                Bio = user.Bio,
            };
        }
    }
}
