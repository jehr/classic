using Domain.Models.Routine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Routines.Level
{
    public interface ILevelService
    {
        Task<List<LevelRoutines>> GetAll();
    }
}
