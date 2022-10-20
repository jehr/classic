using Domain.Models.Routine;
using System.Linq;

namespace Domain.Interfaces.Routines.Level
{
    public interface ILevelRepository
    {
        IQueryable<LevelRoutines> Get();
    }
}
