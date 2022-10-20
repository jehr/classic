using Application.Interfaces.Location;
using Application.Interfaces.Payment;
using Application.Interfaces.Rol;
using Application.Interfaces.Routines;
using Application.Interfaces.Routines.Exercise;
using Application.Interfaces.Routines.GroupMuscular;
using Application.Interfaces.Routines.Level;
using Application.Interfaces.User;
using Application.Services.Location;
using Application.Services.Payment;
using Application.Services.Rol;
using Application.Services.Routines;
using Application.Services.Routines.Exercise;
using Application.Services.Routines.GroupMuscular;
using Application.Services.Routines.Level;
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

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ILevelService, LevelService>(); 
            services.AddScoped<IRoutineService, RoutineService>(); 
            services.AddScoped<IGroupMuscular, GroupMuscular>(); 
            services.AddScoped<IExerciseService, ExerciseService>(); 
        }
    }
}
