using Bogus;
using Moq;
using Portfolio.Application.DTOs.User;
using Portfolio.Application.Interfaces;
using UserEntity = Portfolio.Domain.Entities;
using UseCase = Portfolio.Application.UseCases.User;
using FluentAssertions;


namespace Portfolio.UnitTests.Application.UseCases.User.CreateUser
{
    public class CreateUserTest
    {
        private readonly Faker _faker;

        public CreateUserTest()
        {
            _faker = new Faker();
        }

        [Fact(DisplayName = nameof(CreateUser_ShouldBeValid))]
        [Trait("Application", "Use Cases - User")]
        public async void CreateUser_ShouldBeValid()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var useCase = new UseCase.CreateUser(repositoryMock.Object);
            var input = CreateUserDTO();

            var output = await useCase.ExecuteAsync(input);

            repositoryMock.Verify(repository => repository.AddAsync(It.IsAny<UserEntity.User>()), Times.Once);
            output.Should().NotBeNull();
            output.FirstName.Should().Be(input.FirstName);
            output.LastName.Should().Be(input.LastName);
            output.Email.Should().Be(input.Email);
            output.Bio.Should().Be(input.Bio);
        }

        private CreateUserDTO CreateUserDTO() 
        {
            return new CreateUserDTO
            {
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                Email = _faker.Internet.Email(),
                Bio = _faker.Lorem.Text()
            };
        }
    }
}
