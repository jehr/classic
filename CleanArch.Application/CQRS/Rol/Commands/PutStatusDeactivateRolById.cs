using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Rol.Commands
{
    public class PutStatusDeactivateRolById : IRequest<RolDto>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusDeactivateRolByIdCommandHandler : IRequestHandler<PutStatusDeactivateRolById, RolDto>
    {
        private readonly IRolService _rolService;
      

        public PutStatusDeactivateRolByIdCommandHandler(IRolService rolService) => _rolService = rolService;  

        public async Task<RolDto> Handle(PutStatusDeactivateRolById request, CancellationToken cancellationToken)
        {
            return await _rolService.PutStatusDeactivateRolById(request);
        }
    }
}
