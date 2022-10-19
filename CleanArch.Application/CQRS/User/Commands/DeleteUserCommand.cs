﻿using Application.Common.Response;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.User.Commands
{
    public class DeleteUserCommand : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApiResponse<bool>>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService) => _userService = userService;     

        public async Task<ApiResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUser(request.Id);
           
        }
    }
}
