using Bogus;
using UserEntity = Portfolio.Domain.Entities;
using Portfolio.Domain.ValueObjects;
using System.Globalization;

namespace Portfolio.UnitTests.Application.UseCases.Common
{
    public class BaseUseCaseTest
    {
        public Faker Faker {  get; set; }

        protected BaseUseCaseTest() => Faker = new Faker();

        public UserEntity.User GetValidUser()
        {
            return new UserEntity.User
            {
                Id = Guid.NewGuid(),
                Name = new FullName(GenerateFirstName(), GenerateLastName()),
                Email = GenerateEmail(),
                Bio = GenerateBio(),
            };
        }

        private string GenerateFirstName()
            => Faker.Name.FirstName();

        private string GenerateLastName()
            => Faker.Name.LastName();

        private string GenerateEmail() 
            => Faker.Internet.Email();

        private string GenerateBio()
            => Faker.Lorem.Text();
    }
}
