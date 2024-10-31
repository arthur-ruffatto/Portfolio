
namespace Portfolio.Application.DTOs.User
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        /*public CreateUserDTO(string firstName, string lastName, string email, string bio)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Bio = bio;
        }*/
    }
}
