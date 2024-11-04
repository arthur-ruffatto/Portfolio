using MediatR;
using Portfolio.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces.User
{
    public interface IGetUser : IRequestHandler<GetUserDTO, UserModelOutput>
    {
    }
}
