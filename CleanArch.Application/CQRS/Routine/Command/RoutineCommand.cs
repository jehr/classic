using Application.Interfaces.Routines;
using Application.ViewModel.Routine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Routine.Command
{
    public class RoutineCommand : IRequest<VModelRoutine>
    {
        public int LevelId { get; set; }
        public string Name { get; set; }
        public string Week { get; set; }
    }

    public class RoutineCommandHandler : IRequestHandler<RoutineCommand, VModelRoutine>
    {
        private readonly IRoutineService _routineService;
        public RoutineCommandHandler(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        public async Task<VModelRoutine> Handle(RoutineCommand request, CancellationToken cancellationToken)
        {
            return await _routineService.PostRoutine(request, cancellationToken);
        }
    }
}
