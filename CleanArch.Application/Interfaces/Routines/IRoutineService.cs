using Application.CQRS.Routine.Command;
using Application.ViewModel.Routine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Routines
{
    public interface IRoutineService
    {
        Task<VModelRoutine> PostRoutine(RoutineCommand request, CancellationToken cancellationToken);
        Task<List<Domain.Models.Routine.Routines>> GetRoutines();
    }
}
