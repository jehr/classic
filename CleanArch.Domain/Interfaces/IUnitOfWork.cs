using Domain.Models.Rol;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Models.User.User> UserRepository { get; }
        IRepository<Models.User.UserRol> UserRolRepository { get; }
        IRepository<Rol> RolRepository { get; } 
        void SaveChanges();
        Task SaveChangesAsync();
        public string GetDbConnection();
    }
}
