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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public StateService(IStateRepository stateRepository, IMapper mapper) => (_stateRepository, _mapper) = (stateRepository, mapper);       

        public async Task<List<StateDto>> GetStateByCountryId(Guid id)
        {
            return await _stateRepository.GetAll()
                                         .Where(x => x.CountryId == id)
                                         .OrderBy(x => x.Name)
                                         .ProjectTo<StateDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<StateDto> GetStateByName(string name)
        {
            return await _stateRepository.GetAll()
                                         .Where(x => x.Name.ToUpper().Trim().Contains(name.ToUpper().Trim()))                                      
                                         .ProjectTo<StateDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

        }
        public async Task<bool> CheckUserExistsByName(string name)
        {
            return await _stateRepository.GetAll()
                                                   .Where(x => x.Name.Trim()
                                                   .Equals(name.Trim()))
                                                   .CountAsync() == 0 ? false : true;
        }
    }
}
