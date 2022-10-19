using Application.DTOs.Location;
using Core.Models.Location;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Location
{
    public interface ICityService
    {
        Task<List<CityDto>> GetCityByStateId(Guid id);
        Task<CityDto> GetCityByName(string name);

        Task<bool> CheckUserExistsByName(string name);

    }
}
