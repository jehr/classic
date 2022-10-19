using Application.Common.Response;
using Application.Core.Exceptions;
using Application.CQRS.User.Commands;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.User;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;    
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IUserRolService _userRolService;
        private readonly IMapper _autoMapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUser;      
        private Guid? CreatedBy = null; 
        private Guid? UpdatedBy = null; 
        public UserService(
            IUserRepository userRepository, 
            IUserRolService userRolService,
            ICurrentUserService currentUser,
            IUnitOfWork unitOfWork,
            IMapper autoMapper,
            ILogger<UserService> logger
            
            )
        {
            _userRepository = userRepository;           
            _unitOfWork = unitOfWork;
            _userRolService = userRolService;
            _currentUser = currentUser;
            _autoMapper = autoMapper;
            _logger = logger;
            CreatedBy = _currentUser.GetUserInfo().Id;
            UpdatedBy = _currentUser.GetUserInfo().Id;

        }
        public async Task<ApiResponse<List<UserDto>>> GetUser()
        {
            var response = new ApiResponse<List<UserDto>>();

            try
            {
                response.Data = _autoMapper.Map<List<UserDto>>(await _userRepository.Get()
                                                                                        .Where(x => x.Status)
                                                                                        .OrderBy(x => x.Names)
                                                                                        .ToListAsync());
                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al obtener los Registros, CampaignService en el método GetCampaigns, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al Obtener los Registros, consulte con el administrador  { ex.Message } ";
            }

            return response;

        }

        public UserDto GetUserByDocumentAndSubcampaign(string document, int subCampaignId)
        {
            UserDto users = new UserDto();

            users = _userRepository
                      .Get()
                      .Where(c => c.Document == document.Trim())
                      .ProjectTo<UserDto>(_autoMapper.ConfigurationProvider)
                      .FirstOrDefault();
            return users;

        }   

        public bool CheckById(Guid? Id)
        {
            return _userRepository
                    .Get()
                    .Where(c => c.Id == Id)
                    .Count() == 0 ? false : true;
        }

        public async Task<ApiResponse<UserDto>> PostUser(Domain.Models.User.User user)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                user.CreatedBy = CreatedBy;

                response.Data =  _autoMapper.Map<UserDto>( _userRepository.Post(user));               
                response.Message = "OK";
                response.Result = true;

            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al actualizar el registro, userService en el método PutStatusActivateUserById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
          
        }

        public async Task<ApiResponse<UserDto>> PutStatusActivateUserById(PutStatusActivateUserById request)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                response.Data =_autoMapper.Map<UserDto>(_userRepository
                              .PutStatusActivateUserById(_autoMapper
                              .Map<PutStatusActivateUserById, Domain.Models.User.User>(request, await GetUserById(request.Id))));
            
                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, userService en el método PutStatusActivateUserById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<UserDto>> PutStatusDeactivateUserById(PutStatusDeactivateUserById request)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
               response.Data= _autoMapper.Map<UserDto>( _userRepository
                              .PutStatusDeactivateUserById(_autoMapper
                              .Map<PutStatusDeactivateUserById, Domain.Models.User.User>(request, await GetUserById(request.Id))));

                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, userService en el método PutStatusDeactivateUserById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<UserDto>> PutUser(PutUserCommand request)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                var user = await GetUserById(request.Id);

                _userRolService.DeleteRangeByUserId(user.Id);          

                var ListUserRol = new List<UserRol>() { };

                foreach (var rol in request.Roles)
                {
                    ListUserRol.Add(new UserRol()
                    {
                        RolId = rol,
                        UserId = request.Id
                    });
                }

                if (ListUserRol.Count > 0) _userRolService.PostRange(ListUserRol);

                user = _autoMapper.Map<PutUserCommand, Domain.Models.User.User>(request, user);
                user.UpdatedBy = CreatedBy;
                user.UpdatedAt = DateTime.Now;              

                response.Data = _autoMapper.Map<UserDto>(_userRepository.Put(_autoMapper
                              .Map<PutUserCommand, Domain.Models.User.User>(request, await GetUserById(request.Id))));

                response.Message = "OK";
                response.Result = true;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, userService en el método PutUserCommand, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador  { ex.Message } ";
            }


            return response;
            
        }

        public Domain.Models.User.User PutUserExcel(UserDto userDto)
        {
            var user = _autoMapper.Map<Domain.Models.User.User>(userDto);
            _userRepository.Put(user);

            return user;
        }
     
        public async Task<ApiResponse<bool>> DeleteUser(Guid id)
        {
            var response = new ApiResponse<bool>();

            try
            {               
                var user = await GetUserById(id);            
                _userRolService.DeleteRangeByUserId(user.Id);

                response.Data = _autoMapper.Map<bool>(_userRepository.Delete(await GetUserById(id)));
                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el registro, userService en el método DeleteUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al eliminar el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        private async Task<Domain.Models.User.User> GetUserById(Guid id)
        {
            return await _unitOfWork.UserRepository.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }

        public async  Task<bool> CheckUserExistsByDocument(string document)
        {            
            return await _unitOfWork.UserRepository.Get()
                                                   .Where(x => x.Document.Trim()
                                                   .Equals(document.Trim()))
                                                   .CountAsync() > 0 ? false : true; ;
           
        }
        
    }
}
