using Application.DTOs.Location;
using Application.Interfaces.Location;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Location.Queries
{
    public class GetCountriesByNameQuery : IRequest<CountryDto>
    {
        public string Name { get; set; }
    }

    public class GetCountriesByNameQueryHandler : IRequestHandler<GetCountriesByNameQuery, CountryDto>
    {
        private readonly ICountryService _countryService;
        public GetCountriesByNameQueryHandler(ICountryService countryService) => _countryService = countryService;

        public async Task<CountryDto> Handle(GetCountriesByNameQuery request, CancellationToken cancellationToken)
        {
            return await _countryService.GetCountriesByName(request.Name);

        }

    }
}
