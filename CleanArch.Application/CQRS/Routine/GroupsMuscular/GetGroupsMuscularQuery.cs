using Application.Interfaces.Routines.GroupMuscular;
using Domain.Models.Routine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Routine.GroupsMuscular
{
    public class GetGroupsMuscularQuery : IRequest<List<MuscularGroup>>
    {
    }

    public class GetGroupsMuscularQueryHandler : IRequestHandler<GetGroupsMuscularQuery, List<MuscularGroup>>
    {
        private readonly IGroupMuscular _groupMuscular;
        public GetGroupsMuscularQueryHandler(IGroupMuscular groupMuscular)
        {
            _groupMuscular = groupMuscular;
        }
        public async Task<List<MuscularGroup>> Handle(GetGroupsMuscularQuery request, CancellationToken cancellationToken)
        {
            return await _groupMuscular.GetAll();
        }
    }
}
