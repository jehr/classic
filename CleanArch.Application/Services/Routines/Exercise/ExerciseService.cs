using Application.CQRS.Routine.Exercise;
using Application.Interfaces.Routines.Exercise;
using Application.ViewModel.Exercise;
using AutoMapper;
using Domain.Interfaces.Routines.Exercise;
using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Routines.Exercise
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<VModelResponseExercise> Post(ExerciseCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Exercises>(request);

            var insert = await _exerciseRepository.Post(map);

            if (insert != null)
            {
                return new VModelResponseExercise()
                {
                    Code = "200",
                    Exercise = insert,
                    Message = "Se ha guardado el ejercicio con exito",
                    Status = true
                };
            }

            return new VModelResponseExercise()
            {
                Code = "204",
                Message = "No se ha guardado el ejercicio con exito",
                Status = false
            };
        }
    }
}
