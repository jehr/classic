using Application.Interfaces.Location;
using Application.Interfaces.Rol;
using Application.Interfaces.User;
using Application.Services.Location;
using Application.Services.Rol;
using Application.Services.User;
using CleanArch.Application.Interfaces.Auths;
using CleanArch.Application.Services.Auths;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class ApplicationDependencycontainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Auth
            services.AddScoped<IAuthService, AuthService>();
          
            //User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUserRolService, UserRolService>();

            //Locations
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICountryService, CountryService>();
        }

    }
}
