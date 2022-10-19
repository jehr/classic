using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Rol.Queries
{
    public class GetRolQuery : IRequest<List<RolDto>> { }
    
        public class GetRolQueryHandler : IRequestHandler<GetRolQuery, List<RolDto>>
        {
            private readonly IRolService _rolService;

            public GetRolQueryHandler(IRolService rolService) => _rolService = rolService;
            

            public async Task<List<RolDto>> Handle(GetRolQuery request, CancellationToken cancellationToken)
            {
                return await _rolService.Get();
            }
            
       
        }
}
