using Application.CQRS.Rol.Commands;
using Application.CQRS.Routine.Command;
using Application.CQRS.Routine.Exercise;
using Application.CQRS.User.Commands;
using Application.DTOs.Location;
using Application.DTOs.User;
using AutoMapper;
using Core.Models.Location;
using Domain.Models.Rol;
using Domain.Models.Routine;
using Domain.Models.User;

namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            //Rols
            CreateMap<PutStatusActivateRolById, Rol>();
            CreateMap<PutStatusDeactivateRolById, Rol>();

            //UserRol
            CreateMap<UserRolDto, UserRol>().ReverseMap();
            CreateMap<PutUserCommand, UserRol>();

            CreateMap<PostUserCommand, User>();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RolDto, Rol>().ReverseMap();
            CreateMap<PostRolCommand, Rol>();
            CreateMap<PutRolCommand, Rol>();
            CreateMap<DeleteRolCommand, Rol>();



            CreateMap<PutStatusActivateUserById, User>();
            CreateMap<PutStatusDeactivateUserById, User>();
            CreateMap<PutUserCommand, User>();
            CreateMap<DeleteUserCommand, User>();

            //Locations
            CreateMap<CountryDto, Country>();
            CreateMap<StateDto, State>();
            CreateMap<CityDto, City>();

            CreateMap<RoutineCommand, Routines>();
            CreateMap<ExerciseCommand, Exercises>();

        }
    }
}

