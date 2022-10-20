using Application.Interfaces.Routines.Level;
using Domain.Models.Routine;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Routine.Levels
{
    public class GetLevelsQuery : IRequest<List<LevelRoutines>>
    {
    }

    public class GetLevelsQueryHandler : IRequestHandler<GetLevelsQuery, List<LevelRoutines>>
    {
        private readonly ILevelService _levelService;
        public GetLevelsQueryHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<List<LevelRoutines>> Handle(GetLevelsQuery request, CancellationToken cancellationToken)
        {
            return await _levelService.GetAll();
        }
    }
}
