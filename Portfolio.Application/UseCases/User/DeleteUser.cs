using MediatR;
using Portfolio.Application.DTOs.User;
using Portfolio.Application.Interfaces.User;
using UserEntity = Portfolio.Domain.Entities;
using Portfolio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.UseCases.User
{
    public class DeleteUser : IDeleteUser
    {
        private readonly IUserRepository _userRepository;
        public DeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserDTO request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            await _userRepository.DeleteAsync(user.Id, cancellationToken);
        }
    }
}
