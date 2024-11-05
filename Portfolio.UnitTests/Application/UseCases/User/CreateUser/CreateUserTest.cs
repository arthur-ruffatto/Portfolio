using Bogus;
using Moq;
using Portfolio.Application.DTOs.User;
using UserEntity = Portfolio.Domain.Entities;
using UseCase = Portfolio.Application.UseCases.User;
using FluentAssertions;
using Portfolio.UnitTests.Application.UseCases.Common;
using Portfolio.Domain.Exceptions;
using Portfolio.Domain.Repositories;


namespace Portfolio.UnitTests.Application.UseCases.User.CreateUser
{
    public class CreateUserTest : BaseUseCaseTest
    {

        [Fact(DisplayName = nameof(CreateUser_ShouldBeValid))]
        [Trait("Application", "Use Cases - Create User")]
        public async void CreateUser_ShouldBeValid()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var useCase = new UseCase.CreateUser(repositoryMock.Object);
            var input = CreateUserDTO();

            var output = await useCase.Handle(input, CancellationToken.None);

            repositoryMock.Verify(repository => repository.AddAsync(It.IsAny<UserEntity.User>()), Times.Once);
            output.Should().NotBeNull();
            output.FirstName.Should().Be(input.FirstName);
            output.LastName.Should().Be(input.LastName);
            output.Email.Should().Be(input.Email);
            output.Bio.Should().Be(input.Bio);
        }

        [Fact(DisplayName = nameof(CreateUser_Should_ThrowException_When_InvalidData))]
        [Trait("Application", "Use Cases - Create User")]
        public async void CreateUser_Should_ThrowException_When_InvalidData()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var useCase = new UseCase.CreateUser(repositoryMock.Object);
            var input = CreateUserDTO();
            input.FirstName = "";

            Func<Task> task = async () =>  await useCase.Handle(input, CancellationToken.None);

            await task.Should().ThrowAsync<DomainException>();
            repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<UserEntity.User>()), Times.Never);
        }

        private CreateUserDTO CreateUserDTO() 
        {
            return new CreateUserDTO
            {
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                Email = Faker.Internet.Email(),
                Bio = Faker.Lorem.Text()
            };
        }
    }   
}
