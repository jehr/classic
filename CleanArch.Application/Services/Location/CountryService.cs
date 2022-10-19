using Application.DTOs.Location;
using Application.Interfaces.Location;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces.Location;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Location
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper) => (_countryRepository, _mapper) = (countryRepository, mapper);
      
        public async Task<List<CountryDto>> GetCountries()
        {
            return await _countryRepository.GetAll().ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<CountryDto> GetCountriesByName(string name)
        {
            return await _countryRepository.GetAll()
                                           .Where(x => x.Name.ToUpper().Trim().Contains(name.ToUpper().Trim()))
                                           .ProjectTo<CountryDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

          
        }

        public async Task<bool> CheckUserExistsByName(string name)
        {
            return await _countryRepository.GetAll()
                                                   .Where(x => x.Name.Trim()
                                                   .Equals(name.Trim()))
                                                   .CountAsync() == 0 ? false : true;
        }

    }
}
