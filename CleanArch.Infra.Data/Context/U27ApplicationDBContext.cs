using Core.Models.Location;
using Domain.Models.Payment;
using Domain.Models.Rol;
using Domain.Models.Routine;
using Domain.Models.User;
using Domain.Models.Valoration;
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

        #region Payment
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentHistories> PaymentHistories { get; set; }
        #endregion

        #region Valoration
        public DbSet<Valorations> Valorations { get; set; }
        public DbSet<DetailsValoration> DetailsValoration { get; set; }
        #endregion

        #region Routines
        public DbSet<LevelRoutines> LevelRoutines { get; set; }
        public DbSet<Routines> Routines { get; set; }
        public DbSet<MuscularGroup> MuscularGroup { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
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
