using CleanArch.Infra.Data.Context;
using Domain.Interfaces;
using Domain.Models.Rol;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly U27ApplicationDBContext _ctx;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRol> _userRolRepository;
        private readonly IRepository<Rol> _rolRepository;   

        public UnitOfWork(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IRepository<UserRol> UserRolRepository => _userRolRepository ?? new BaseRepository<UserRol>(_ctx);
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_ctx);
        public IRepository<Rol> RolRepository => _rolRepository ?? new BaseRepository<Rol>(_ctx);   

        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public string GetDbConnection()
        {
            return _ctx.Database.GetDbConnection().ConnectionString;
        }
    }
}
