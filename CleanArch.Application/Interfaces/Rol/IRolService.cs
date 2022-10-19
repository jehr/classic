using Application.CQRS.Rol.Commands;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Rol
{
    public interface IRolService
    {
        Task<List<RolDto>> Get();
        Domain.Models.Rol.Rol GetById(Guid Id);
        Task<RolDto> PostRol(PostRolCommand rolCommand);
        Task<RolDto> PutRol(PutRolCommand rolCommand);
        Task<bool> DeleteRol(Guid id);
        bool CheckById(Guid? Id);
        Task<RolDto> PutStatusActivateRolById(PutStatusActivateRolById request);

        Task<RolDto> PutStatusDeactivateRolById(PutStatusDeactivateRolById request);
    }
}
