using FluentAssertions;
using Moq;
using Portfolio.Application.DTOs.User;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Repositories;
using Portfolio.UnitTests.Application.UseCases.Common;
using UseCase = Portfolio.Application.UseCases.User;
using UserEntity = Portfolio.Domain.Entities;

namespace Portfolio.UnitTests.Application.UseCases.User.GetUser
{
    public class GetUserTest : BaseUseCaseTest
    {
        [Fact(DisplayName = nameof(GetUser_Should_BeValid))]
        [Trait("Application", "Use Cases - Get User")]
        public async void GetUser_Should_BeValid()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var useCase = new UseCase.GetUser(repositoryMock.Object);
            var validUser = GetValidUser();
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(validUser);
            var input = GetUserDTO();

            var output = await useCase.ExecuteAsync(input);

            repositoryMock.Verify(repository => repository.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            output.Should().NotBeNull();
            output.FirstName.Should().NotBeNullOrWhiteSpace();
            output.LastName.Should().NotBeNullOrWhiteSpace();
            output.Email.Should().NotBeNullOrWhiteSpace();
            output.Bio.Should().NotBeNull();
        }

        [Fact(DisplayName = nameof(GetUser_Should_ThrowException_When_InvalidData))]
        [Trait("Application", "Use Cases - Get User")]
        public async void GetUser_Should_ThrowException_When_InvalidData()
        {
            var repositoryMock = new Mock<IUserRepository>();
            var useCase = new UseCase.GetUser(repositoryMock.Object);
            var input = GetUserDTO();
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new NotFoundException($"User Id: {input.Id} not found"));

            Func<Task> task = async () => await useCase.ExecuteAsync(input);

            await task.Should().ThrowAsync<NotFoundException>();
            repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<UserEntity.User>()), Times.Never);
        }

        private GetUserDTO GetUserDTO()
        {
            return new GetUserDTO
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
