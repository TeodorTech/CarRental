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
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet]
        [Route("{index}")]
        public async Task<IActionResult> GetById([FromRoute]int index)
        {
            var result = await _mediator.Send(new GetUserById { UserId = index });
            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsers());
            var mappedResult = _mapper.Map<List<UserGetDto>>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserPutPostDto user)
        {
            var command = _mapper.Map<CreateUser>(user);
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id,[FromBody] UserPutPostDto user)
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
             await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser([FromQuery]int id)
        {
            var deleteUser = await _mediator.Send(new DeleteUser { UserId = id });
            return NoContent();
        }
    }
}
