using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Routines
{
    public interface IRoutineRepository
    {
        Task<Models.Routine.Routines> Post(Models.Routine.Routines routine);
        IQueryable<Models.Routine.Routines> Get();
    }
}
