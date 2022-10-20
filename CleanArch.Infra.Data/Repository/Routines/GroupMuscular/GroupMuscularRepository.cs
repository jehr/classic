using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Routines.GroupMuscular;
using Domain.Models.Routine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Repository.Routines.GroupMuscular
{
    public class GroupMuscularRepository : IGroupMuscularRepository
    {
        private U27ApplicationDBContext _ctx;
        public GroupMuscularRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<MuscularGroup> Get()
        {
            return _ctx.MuscularGroup;
        }
    }
}
