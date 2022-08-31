using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Commands;
using CarRental.Domain;

namespace CarRental.Api.Profiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<CarPutPostDto, CreateCar>();
            CreateMap<Car, CarGetDto>();
        }
    }
}
