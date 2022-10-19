using Application.DTOs.Location;
using Application.Interfaces.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Location.Queries
{
    public class GetStateByNameQuery : IRequest<StateDto>
    {
        public string Name { get; set; }
    }
    public class GetStateByNameQueryHandler : IRequestHandler<GetStateByNameQuery, StateDto>
    {
        private readonly IStateService _stateService;
        public GetStateByNameQueryHandler(IStateService stateService) => _stateService = stateService;

        public async Task<StateDto> Handle(GetStateByNameQuery request, CancellationToken cancellationToken)
        {
            return await _stateService.GetStateByName(request.Name);

        }

    }
}
