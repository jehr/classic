using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Routines.Level;
using Domain.Models.Payment;
using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Routines.Level
{
    public class LevelRepository : ILevelRepository
    {
        private U27ApplicationDBContext _ctx;
        public LevelRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<LevelRoutines> Get()
        {
            return _ctx.LevelRoutines;
        }
    }
}
