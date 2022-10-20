using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Routines.GroupMuscular
{
    public interface IGroupMuscularRepository
    {
        IQueryable<MuscularGroup> Get();
    }
}
