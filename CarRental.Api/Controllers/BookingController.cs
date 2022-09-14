using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Bookings.Command;
using CarRental.Application.Bookings.Queries;
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

        
        [HttpDelete]
        [Route("{bookingId}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int bookingId)
        {
            var deleteBooking = await _mediator.Send(new DeleteBooking { Id = bookingId });
            if (deleteBooking == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var listOfBookings = await _mediator.Send(new GetAllBookings { });
            var mappedResult = _mapper.Map<List<BookingGetDto>>(listOfBookings);
            return Ok(mappedResult);
        }
        [HttpGet]
        [Route("{bookingId}")]
        public async Task <IActionResult> GetBookingById([FromRoute] int bookingId)
        {
            var booking = await _mediator.Send(new GetBookingById { Id = bookingId });
            if (booking == null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<BookingGetDto>(booking);
            return Ok(mappedResult);
        }
    }
}
