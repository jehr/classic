using CleanArch.Infra.Data.Context;
using Core.Models.Location;
using Domain.Interfaces.Location;
using System.Linq;

namespace Infra.Data.Repository.Location
{
    public class StateRepository : IStateRepository
    {
        private U27ApplicationDBContext _ctx;
        public StateRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<State> GetAll()
        {
            return _ctx.States;
        }
    }
}
