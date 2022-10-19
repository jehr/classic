using Application.Core.Exceptions;
using Application.CQRS.Rol.Commands;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Domain.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Rol
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;

        public RolService(
            IRolRepository rolRepository,
            IMapper autoMapper,
            IUnitOfWork unitOfWork
        )
        {
            _rolRepository = rolRepository;
            _autoMapper = autoMapper;
            _unitOfWork = unitOfWork;
        }

        public bool CheckById(Guid? Id)
        {
            return _rolRepository
                    .Get()
                    .Where(c => c.Id == Id)
                    .Count() == 0 ? false : true;
        }

        public Domain.Models.Rol.Rol GetById(Guid Id)
        {
            return _rolRepository
                     .Get()
                     .Where(c => c.Id == Id)
                     .FirstOrDefault();
        }

        public Task<List<RolDto>> Get()
        {
            return  _unitOfWork.RolRepository
                    .Get()
                    .ProjectTo<RolDto>(_autoMapper.ConfigurationProvider)
                    .ToListAsync();
            
        }

        public async Task<RolDto> PostRol(PostRolCommand rolCommand)
        {
            return _autoMapper.Map<RolDto>(await _unitOfWork.RolRepository.Add(_autoMapper.Map<Domain.Models.Rol.Rol>(rolCommand)));
        }

        public async Task<RolDto> PutRol(PutRolCommand rolCommand)
        { 
            return _autoMapper.Map<RolDto>(await _unitOfWork.RolRepository
                              .Put(_autoMapper.Map<PutRolCommand, Domain.Models.Rol.Rol>(rolCommand, await GetRolById(rolCommand.Id))));
        }

        public async Task<bool> DeleteRol(Guid id)
        {
            return await _unitOfWork.RolRepository.Delete(_autoMapper.Map<Domain.Models.Rol.Rol>(await GetRolById(id)));
        }

        public async Task<RolDto> PutStatusActivateRolById(PutStatusActivateRolById request)
        {          
            return _autoMapper.Map<RolDto>(_rolRepository
                              .PutStatusActivateRolById(_autoMapper.Map<PutStatusActivateRolById, Domain.Models.Rol.Rol>(request, await GetRolById(request.Id))));
        }

        public async Task<RolDto> PutStatusDeactivateRolById(PutStatusDeactivateRolById request)
        {
            return _autoMapper.Map<RolDto>(_rolRepository
                              .PutStatusDeactivateRolById(_autoMapper.Map<PutStatusDeactivateRolById, Domain.Models.Rol.Rol>(request, await GetRolById(request.Id))));
        }

        private async Task<Domain.Models.Rol.Rol> GetRolById(Guid id)
        {
            return await _unitOfWork.RolRepository.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }
    }
}
