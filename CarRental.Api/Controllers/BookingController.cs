using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Bookings.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BookingController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookingPutPostDto car)
        {
            var command = _mapper.Map<CreateBooking>(car);
            var newBook = await _mediator.Send(command);
            var mappedBooking = _mapper.Map<BookingGetDto>(newBook);
            return Ok(mappedBooking);
        }
    }
}
