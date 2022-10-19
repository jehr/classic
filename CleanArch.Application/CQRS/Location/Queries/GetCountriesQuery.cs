using Application.DTOs.Location;
using Application.Interfaces.Location;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Location.Queries
{
    public class GetCountriesQuery : IRequest<List<CountryDto>> { }

    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly ICountryService _countryService;
        public GetCountriesQueryHandler(ICountryService countryService) => _countryService = countryService;

        public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _countryService.GetCountries();

        }

    }
}
