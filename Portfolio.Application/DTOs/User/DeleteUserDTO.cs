using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs.User
{
    public class DeleteUserDTO : IRequest
    {
        public Guid Id { get; set; }
    }
}
