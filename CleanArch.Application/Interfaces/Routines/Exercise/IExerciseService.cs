using Application.CQRS.Routine.Exercise;
using Application.ViewModel.Exercise;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Routines.Exercise
{
    public interface IExerciseService
    {
        Task<VModelResponseExercise> Post(ExerciseCommand request, CancellationToken cancellationToken);
    }
}
