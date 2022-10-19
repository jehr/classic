using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.User.Commands
{
    public class PutStatusDeactivateUserById : IRequest<ApiResponse<UserDto>>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusDeactivateUserByIdCommandHandler : IRequestHandler<PutStatusDeactivateUserById, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;      

        public PutStatusDeactivateUserByIdCommandHandler(IUserService userService) =>
            (_userService) = (userService);
      

        public async Task<ApiResponse<UserDto>> Handle(PutStatusDeactivateUserById request, CancellationToken cancellationToken)
        {          
            return await  _userService.PutStatusDeactivateUserById(request);
        }
    }

}
