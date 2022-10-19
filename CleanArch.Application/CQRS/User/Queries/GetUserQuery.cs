using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class GetUserQuery : IRequest<ApiResponse<List<UserDto>>>
    {
       
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApiResponse<List<UserDto>>>
    {
        private readonly IUserService _userService;
        public GetUserQueryHandler(IUserService userService) => _userService = userService;      

        public async Task<ApiResponse<List<UserDto>>>Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUser();
        }

    }

 

}
