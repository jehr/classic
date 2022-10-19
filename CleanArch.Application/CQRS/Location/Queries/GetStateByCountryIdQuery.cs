using Application.DTOs.Location;
using Application.Interfaces.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Location.Queries
{
    public class GetStateByCountryIdQuery : IRequest<List<StateDto>>
    {
        public Guid Id { get; set; }
    }
    public class GetStateByCountryIdQueryHandler : IRequestHandler<GetStateByCountryIdQuery, List<StateDto>>
    {
        private readonly IStateService _stateService;
        public GetStateByCountryIdQueryHandler(IStateService stateService) => _stateService = stateService;

        public async Task<List<StateDto>> Handle(GetStateByCountryIdQuery request, CancellationToken cancellationToken)
        {
            return await _stateService.GetStateByCountryId(request.Id);

        }

    }
}
