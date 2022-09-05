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
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CarController> _logger;
        public CarController(IMediator mediator, IMapper mapper, ILogger<CarController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
    
        [HttpGet]
        [Route("{carId}")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            _logger.LogInformation("Retrieving the car by Id");
            var result = await _mediator.Send(new GetCarById { CarId = carId });
            if (result == null)
            {
                _logger.LogWarning("The Id could not be found");
                return null;
            }
            var mappedResult = _mapper.Map<CarGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Retrieving the list of cars");
            var query = new GetAllCars();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<CarGetDto>>(result);
            _logger.LogInformation($"There are {result.Count} cars in the fleet");
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CarPutPostDto car)
        {
            var command = _mapper.Map<CreateCar>(car);
            var newCar = await _mediator.Send(command);
            var mappedCar = _mapper.Map<CarGetDto>(newCar);
            _logger.LogInformation($"{car.Make} {car.Model} was created  at {DateTime.Now.TimeOfDay}");
            return Ok(mappedCar);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar([FromQuery] int id)
        {   
            var deleteCar = await _mediator.Send(new DeleteCar { CarId = id });
            _logger.LogInformation($"Car with ID {id} was deleted");
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromQuery] int id, [FromBody] CarPutPostDto car)
        {
            var command = new UpdateCar
            {
                Id = id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
            };
            _logger.LogInformation("Request with the updated car was sent!");
            var updatedCar = await _mediator.Send(command);
            _logger.LogInformation("The car was updated");
            return Ok(updatedCar);
        }

    }
}
