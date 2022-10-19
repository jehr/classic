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
    public class PutStatusActivateUserById : IRequest<ApiResponse<UserDto>>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusActivateUserByIdCommandHandler : IRequestHandler<PutStatusActivateUserById, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;

        public PutStatusActivateUserByIdCommandHandler(IUserService userService) => _userService = userService;

        public async Task<ApiResponse<UserDto>> Handle(PutStatusActivateUserById request, CancellationToken cancellationToken)
        {
            return await _userService.PutStatusActivateUserById(request);
        }
    }
}
