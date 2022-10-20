using Application.Interfaces.Routines.Exercise;
using Application.ViewModel.Exercise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Routine.Exercise
{
    public class ExerciseCommand : IRequest<VModelResponseExercise>
    {
        public int RoutineId { get; set; }
        public int MuscularGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExerciseCommandHandler : IRequestHandler<ExerciseCommand, VModelResponseExercise>
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseCommandHandler(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        public async Task<VModelResponseExercise> Handle(ExerciseCommand request, CancellationToken cancellationToken)
        {
            return await _exerciseService.Post(request, cancellationToken);
        }
    }
}
