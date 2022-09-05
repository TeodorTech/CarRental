using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Users;
using CarRental.Application.Users.Commands;
using CarRental.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        public UserController(IMediator mediator, IMapper mapper, ILogger<UserController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {
            _logger.LogInformation("Retrieving the user by Id");
            var result = await _mediator.Send(new GetUserById { UserId = userId });
            if (result == null)
            {
                _logger.LogWarning("The Id could not be found");
                return null;
            }
            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Retrieving the list of cars");
            var result = await _mediator.Send(new GetAllUsers());
            var mappedResult = _mapper.Map<List<UserGetDto>>(result);
            _logger.LogInformation($"There are {result.Count} users in the database");
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserPutPostDto user)
        {
            var command = _mapper.Map<CreateUser>(user);
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<UserGetDto>(result);
            _logger.LogInformation($"A new user was created at {DateTime.Now.TimeOfDay}");
            return Ok(mappedResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery] int id,[FromBody] UserPutPostDto user)
        {
            var command = new UpdateUser
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                City = user.City,
                Email = user.Email,

            };
            _logger.LogInformation("Request with the updated user was sent!");
            var result= await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveUser([FromRoute]int userId)
        {
            var deleteUser = await _mediator.Send(new DeleteUser { UserId = userId });
            _logger.LogInformation("A user was deleted from the list");
            return NoContent();
        }
    }
}
