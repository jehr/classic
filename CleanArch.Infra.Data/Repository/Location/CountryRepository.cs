using CleanArch.Infra.Data.Context;
using Core.Models.Location;
using Domain.Interfaces.Location;
using System.Linq;

namespace Infra.Data.Repository.Location
{
    public class CountryRepository : ICountryRepository
    {
        private U27ApplicationDBContext _ctx;
        public CountryRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Country> GetAll()
        {
            return _ctx.Countries;
        }
    }
}
