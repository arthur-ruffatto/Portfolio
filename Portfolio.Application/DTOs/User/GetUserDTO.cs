using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs.User
{
    public class GetUserDTO : IRequest<UserModelOutput>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
