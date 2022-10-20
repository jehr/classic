using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Routines.GroupMuscular
{
    public interface IGroupMuscular
    {
        Task<List<MuscularGroup>> GetAll();
    }
}
