using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Cars.Commands;
using CarRental.Application.Cars.Queries;
using CarRental.Application.Commands;
using CarRental.Application.Queries;
using CarRental.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarController(IMediator mediator,IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{carId}")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            var result = await  _mediator.Send(new GetCarById { CarId = carId });
            var mappedResult = _mapper.Map<CarGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCars();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<CarGetDto>>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody]CarPutPostDto car)
        {
            var command = _mapper.Map<CreateCar>(car);
          
            var newCar = await _mediator.Send(command);

            var mappedCar = _mapper.Map<CarGetDto>(newCar);
            return Ok(mappedCar);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar([FromQuery]int id)
        {
            var deleteCar = await _mediator.Send(new DeleteCar { CarId = id });
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(int id,[FromBody] CarPutPostDto car)
        {
            var command = new UpdateCar
            {
                Id = id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
            };
            var updatedCar = await _mediator.Send(command);
            return NoContent();

        }
      
    }
}
