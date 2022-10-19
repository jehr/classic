using Application.DTOs.Location;
using Application.Interfaces.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Location.Queries
{
    public class GetCityByNameQuery : IRequest<CityDto>
    {
        public string Name { get; set; }
    }

    public class GetCityByNameQueryHandler : IRequestHandler<GetCityByNameQuery, CityDto>
    {
        private readonly ICityService _cityService;
        public GetCityByNameQueryHandler(ICityService cityService) => _cityService = cityService;

        public async Task<CityDto> Handle(GetCityByNameQuery request, CancellationToken cancellationToken)
        {
            return await _cityService.GetCityByName(request.Name);

        }

    }

}
