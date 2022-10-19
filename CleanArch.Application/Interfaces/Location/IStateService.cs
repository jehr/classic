using Application.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Location
{
    public interface IStateService
    {
        Task<List<StateDto>> GetStateByCountryId(Guid id);

        Task<StateDto> GetStateByName(string name);

        Task<bool> CheckUserExistsByName(string name);

    }
}
