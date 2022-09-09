using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Bookings.Command;
using CarRental.Domain;

namespace CarRental.Api.Profiles
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingPutPostDto, CreateBooking>();
            CreateMap<Booking, BookingGetDto>();
        }
    }
}
