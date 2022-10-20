using Application.Interfaces.Routines.GroupMuscular;
using Domain.Interfaces.Routines.GroupMuscular;
using Domain.Models.Routine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Routines.GroupMuscular
{
    public class GroupMuscular : IGroupMuscular
    {
        private readonly IGroupMuscularRepository _groupMuscularRepository;
        public GroupMuscular(IGroupMuscularRepository groupMuscularRepository)
        {
            _groupMuscularRepository = groupMuscularRepository;
        }
        public async Task<List<MuscularGroup>> GetAll()
        {
            return await _groupMuscularRepository.Get().ToListAsync();
        }
    }
}
