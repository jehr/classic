using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Rol.Commands
{
    public class PutRolCommand : IRequest<RolDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool Status { get; set; }
    }

    public class PutRolCommandHandler : IRequestHandler<PutRolCommand, RolDto>
    {
        private readonly IRolService _rolService;
        public PutRolCommandHandler(IRolService rolService) => _rolService = rolService;
     
        public async Task<RolDto> Handle(PutRolCommand request, CancellationToken cancellationToken)
        {
            return await _rolService.PutRol(request);
          
        }
    }
}
