using Application.DTOs.User;
using Application.Interfaces.Rol;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Rol.Commands
{
    public class PostRolCommand : IRequest<RolDto>
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Status { get; set; }
    }

    public class PostRolCommandHandler : IRequestHandler<PostRolCommand, RolDto>
    {
        private readonly IRolService _rolService;  
        public PostRolCommandHandler(IRolService rolService) => _rolService = rolService;


        public async Task<RolDto> Handle(PostRolCommand request, CancellationToken cancellationToken)
        {
            return await _rolService.PostRol(request);

        }
    }

}
