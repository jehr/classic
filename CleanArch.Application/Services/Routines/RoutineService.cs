using Application.CQRS.Routine.Command;
using Application.Interfaces.Routines;
using Application.ViewModel.Routine;
using AutoMapper;
using Domain.Interfaces.Routines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Routines
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IMapper _mapper;
        public RoutineService(IRoutineRepository routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<List<Domain.Models.Routine.Routines>> GetRoutines()
        {
            return await _routineRepository.Get()
                .Include(x => x.LevelRoutines)
                .ToListAsync();
        }

        public async Task<VModelRoutine> PostRoutine(RoutineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var map = _mapper.Map<Domain.Models.Routine.Routines>(request);

                var add = await _routineRepository.Post(map);

                if (add != null)
                {
                    return new VModelRoutine()
                    {
                        Message = "Se ha guardado la rutina con éxito",
                        Code = "200",
                        Status = true,
                        Routine = add
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return new VModelRoutine()
            {
                Message = "No ha guardado la rutina con éxito",
                Code = "200",
                Status = true
            };
        }
    }
}
