using MediatR;
using Portfolio.Application.DTOs.User;

namespace Portfolio.Application.Interfaces.User
{
    public interface IDeleteUser : IRequestHandler<DeleteUserDTO>
    {
    }
}
