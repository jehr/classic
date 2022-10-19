using Application.DTOs.Location;
using Application.DTOs.User;
using AutoMapper;
using Core.Models.Location;
using Domain.Models.Rol;
using Domain.Models.User;

namespace CleanArch.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            //User
            CreateMap<User, UserDto>();
            CreateMap<UserRol, UserRolDto>();
            CreateMap<Rol, RolDto>();

            //Location           
            CreateMap<City, CityDto>();
            CreateMap<State, StateDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}