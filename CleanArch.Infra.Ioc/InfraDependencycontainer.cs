using Domain.Interfaces;
using Domain.Interfaces.Location;
using Domain.Interfaces.User;
using Infra.Data.Repository;
using Infra.Data.Repository.Location;
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

            #region GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }

    }
}
