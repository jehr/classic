using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Routines
{
    public class RoutineRepository : IRoutineRepository
    {
        private U27ApplicationDBContext _ctx;
        public RoutineRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Domain.Models.Routine.Routines> Get()
        {
            return _ctx.Routines;
        }

        public async Task<Domain.Models.Routine.Routines> Post(Domain.Models.Routine.Routines routine)
        {
            try
            {
                _ctx.Routines.Add(routine);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("routine", "La rutina no pudo ser agregada");
            }

            return routine;
        }
    }
}
