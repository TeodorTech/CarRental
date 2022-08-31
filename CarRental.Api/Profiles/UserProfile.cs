using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Users.Commands;
using CarRental.Domain;

namespace CarRental.Api.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPutPostDto, CreateUser>();
        }
        
    }
}
