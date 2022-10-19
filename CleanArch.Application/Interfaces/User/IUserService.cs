using Application.Common.Response;
using Application.CQRS.User.Commands;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ApiResponse<List<UserDto>>> GetUser();
        Task<bool> CheckUserExistsByDocument(string document);    
        UserDto GetUserByDocumentAndSubcampaign(string document, int subCampaignId);
        Domain.Models.User.User PutUserExcel(UserDto userDto);       
        Task<ApiResponse<UserDto>> PostUser(Domain.Models.User.User user);
        Task<ApiResponse<UserDto>> PutStatusActivateUserById(PutStatusActivateUserById request);
        Task<ApiResponse<UserDto>> PutStatusDeactivateUserById(PutStatusDeactivateUserById request);
        Task<ApiResponse<UserDto>> PutUser(PutUserCommand request);
        Task<ApiResponse<bool>> DeleteUser(Guid id);
        bool CheckById(Guid? Id);        
       
    }
}
