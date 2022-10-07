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
        private readonly ILogger<BookingController> _logger;
        public BookingController(IMediator mediator,IMapper mapper, ILogger<BookingController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookingPutPostDto book)
        {
            var command = _mapper.Map<CreateBooking>(book);
            var newBook = await _mediator.Send(command);
            var mappedBooking = _mapper.Map<BookingGetDto>(newBook);
            _logger.LogInformation($"A new booking was created at {DateTime.Now.TimeOfDay}");
            return Ok(mappedBooking);
        }

        
        [HttpDelete]
        [Route("{bookingId}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int bookingId)
        {
            var deleteBooking = await _mediator.Send(new DeleteBooking { Id = bookingId });
            if (deleteBooking == null)
            {
                _logger.LogWarning("The Id could not be found");
                return NotFound();
            }
            _logger.LogInformation("A book was deleted from the list");
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            _logger.LogInformation("Retrieving the list of bookings");
            var listOfBookings = await _mediator.Send(new GetAllBookings { });
            var mappedResult = _mapper.Map<List<BookingGetDto>>(listOfBookings);
            _logger.LogInformation($"There are {listOfBookings.Count} bookings in the database");

            return Ok(mappedResult);
        }
        [HttpGet]
        [Route("{bookingId}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int bookingId)
        {
            _logger.LogInformation("Retrieving the booking by Id");
            var booking = await _mediator.Send(new GetBookingById { Id = bookingId });
            if (booking == null)
            {
                _logger.LogWarning("The Id could not be found");
                return NotFound();
            }
            var mappedResult = _mapper.Map<BookingGetDto>(booking);
            return Ok(mappedResult);
        }


        [HttpGet]
        [Route("getbyuser/{userId}")]
        public async Task<IActionResult> GetBookingByUserId([FromRoute] int userId)
        {
            var booking = await _mediator.Send(new GetBookingsByUserId { UserId = userId });
            if (booking == null)
            {
                _logger.LogWarning("The Id could not be found");
                return NotFound();
            }
            var mappedResult = _mapper.Map<List<BookingGetDto>>(booking);
            return Ok(mappedResult);
        }
    }
}
