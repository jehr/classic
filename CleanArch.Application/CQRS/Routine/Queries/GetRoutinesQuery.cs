using Application.Interfaces.Routines;
using Domain.Models.Routine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Routine.Queries
{
    public class GetRoutinesQuery : IRequest<List<Routines>>
    {
    }

    public class GetRoutinesQueryHandler : IRequestHandler<GetRoutinesQuery, List<Routines>>
    {
        private readonly IRoutineService _routineService;
        public GetRoutinesQueryHandler(IRoutineService routineService)
        {
            _routineService = routineService;
        }
        public async Task<List<Routines>> Handle(GetRoutinesQuery request, CancellationToken cancellationToken)
        {
            return await _routineService.GetRoutines();
        }
    }
}
