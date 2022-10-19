using Application.Interfaces.Rol;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Rol.Commands
{
    public class DeleteRolCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteRolCommand, bool>
    {
        private readonly IRolService _rolService;
        public DeleteUserCommandHandler(IRolService rolService) => _rolService = rolService;

        public async Task<bool> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
           return await _rolService.DeleteRol(request.Id);
         
        }
    }
}
