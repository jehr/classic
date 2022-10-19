using Core.Models.Location;
using Domain.Models.Rol;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace CleanArch.Infra.Data.Context
{
    public class U27ApplicationDBContext : DbContext
    {
        public U27ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        #region User
        public DbSet<User> Users { get; set; }

        [NotMapped]
        public DbSet<UserRol> UserRols { get; set; }

        #endregion

        #region Rol
        public DbSet<Rol> Rols { get; set; }

        #endregion

        #region Location
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all assemblies from configurations folder in infra.data
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }
    }
}
