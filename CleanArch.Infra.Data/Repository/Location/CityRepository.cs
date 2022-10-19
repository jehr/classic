using CleanArch.Infra.Data.Context;
using Core.Models.Location;
using Domain.Interfaces.Location;
using System.Linq;

namespace Infra.Data.Repository.Location
{
    public class CityRepository : ICityRepository
    {
        private U27ApplicationDBContext _ctx;
        public CityRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<City> GetAll()
        {
            return _ctx.Cities;
        }
    }
}
