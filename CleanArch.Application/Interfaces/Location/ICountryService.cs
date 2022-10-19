using Application.DTOs.Location;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Location
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetCountries();
        Task<CountryDto> GetCountriesByName(string Name);

        Task<bool> CheckUserExistsByName(string name);

    }
}
