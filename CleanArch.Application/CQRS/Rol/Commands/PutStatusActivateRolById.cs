using Application.DTOs.User;
using Application.Interfaces.Rol;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Rol.Commands
{
    public class PutStatusActivateRolById : IRequest<RolDto>
    {
        public Guid Id { get; set; }
    }

    public class PutStatusActivateRolByIdCommandHandler : IRequestHandler<PutStatusActivateRolById, RolDto>
    {
        private readonly IRolService _rolService;   

        public PutStatusActivateRolByIdCommandHandler(IRolService rolService, IMapper mapper) => _rolService = rolService;       

        public async Task<RolDto> Handle(PutStatusActivateRolById request, CancellationToken cancellationToken)
        {
            return await _rolService.PutStatusActivateRolById(request);
            
        }
    }
}
