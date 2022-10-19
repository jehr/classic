using Application.DTOs.Location;
using Application.Interfaces.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Location.Queries
{
    public class GetCityByStateIdQuery : IRequest<List<CityDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetCityByStateIdQueryHandler : IRequestHandler<GetCityByStateIdQuery, List<CityDto>>
    {
        private readonly ICityService _cityService;
        public GetCityByStateIdQueryHandler(ICityService cityService) => _cityService = cityService;

        public async Task<List<CityDto>> Handle(GetCityByStateIdQuery request, CancellationToken cancellationToken)
        {
            return await _cityService.GetCityByStateId(request.Id);

        }

    }

}
