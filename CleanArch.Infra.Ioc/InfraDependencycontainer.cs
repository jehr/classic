using Domain.Interfaces;
using Domain.Interfaces.Location;
using Domain.Interfaces.Payment;
using Domain.Interfaces.Routines;
using Domain.Interfaces.Routines.Exercise;
using Domain.Interfaces.Routines.GroupMuscular;
using Domain.Interfaces.Routines.Level;
using Domain.Interfaces.User;
using Infra.Data.Repository;
using Infra.Data.Repository.Location;
using Infra.Data.Repository.Payment;
using Infra.Data.Repository.Routines;
using Infra.Data.Repository.Routines.Exercise;
using Infra.Data.Repository.Routines.GroupMuscular;
using Infra.Data.Repository.Routines.Level;
using Infra.Data.Repository.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class InfraDependencycontainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();

            //User
            services.AddScoped<IUserRepository, UserRepository>();

            //Rol
            services.AddScoped<IRolRepository, RolRepository>();

            //UserRol
            services.AddScoped<IUserRolRepository, UserRolRepository>();

            //Locatiosn
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IRoutineRepository, RoutineRepository>(); 
            services.AddScoped<IGroupMuscularRepository, GroupMuscularRepository>(); 
            services.AddScoped<IExerciseRepository, ExerciseRepository>();


            #region GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            
        }

    }
}
