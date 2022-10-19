using Application.DTOs.Location;
using Application.Interfaces.Location;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces.Location;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Location
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper) => (_cityRepository, _mapper) = (cityRepository, mapper);

        public async Task<List<CityDto>> GetCityByStateId(Guid id)
        {
            return await _cityRepository.GetAll()
                                        .Where(x => x.StateId == id)
                                        .OrderBy(x => x.Name)
                                        .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync();

        }

        public async Task<CityDto> GetCityByName(string name)
        {

            var source = await _cityRepository.GetAll()
                                        .Where(x => x.Name.ToUpper().Trim().Contains(name.ToUpper().Trim()))
                                        .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                                        .FirstOrDefaultAsync();

            return source;

        }

        public async Task<bool> CheckUserExistsByName(string name)
        {
            return await _cityRepository.GetAll()
                                                   .Where(x => x.Name.Trim()
                                                   .Equals(name.Trim()))
                                                   .CountAsync() == 0 ? false : true;
        }
    }
}
