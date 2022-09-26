using AutoMapper;
using CarRental.Api.DTO;
using CarRental.Application.Cars.Commands;
using CarRental.Application.Cars.Queries;
using CarRental.Application.Commands;
using CarRental.Application.Queries;
using CarRental.Domain;
using MediatR;
using Microsoft.AspNetCore.Cors;
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
        public async Task<IActionResult> GetCarById([FromRoute] int carId)
        {
            _logger.LogInformation("Retrieving the car by Id");
            var result = await _mediator.Send(new GetCarById { CarId = carId });
            if (result == null)
            {
                _logger.LogWarning("The Id could not be found");
                return NotFound();
            }
            var mappedResult = _mapper.Map<CarGetDto>(result);
            return Ok(mappedResult);
        }
        
        [HttpGet]
        [Route("getallcars")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Retrieving the list of cars");
            var query = new GetAllCars();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<CarGetDto>>(result);
            _logger.LogInformation($"There are {result.Count} cars in the fleet");
            return Ok(mappedResult);
        }
        [HttpGet]
        [Route("getpage/{page}")]
        public async Task<IActionResult> GetAllFromPage([FromRoute] int page)
        {
            _logger.LogInformation($"Retrieving the list of cars from page {page}");
            var query = new GetAllCars();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<CarGetDto>>(result);

            var pageResult = 2f;
            var pageCount = Math.Ceiling( result.Count() / pageResult);
            var cars =  result.Skip((page - 1) * (int)pageResult).Take((int)pageResult).ToList();

            var response = new ItemResponse<Car>
            {
                Items = cars,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            _logger.LogInformation($"There are {result.Count} cars in the fleet");
            return Ok(response);
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
        [Route("{carId}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int carId)
        {   
            var deleteCar = await _mediator.Send(new DeleteCar { CarId = carId});
            _logger.LogInformation($"Car with ID {carId} was deleted");
            return NoContent();
        }

        [HttpPut]
        [Route("{carId}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int carId, [FromBody] CarPutPostDto car)
        {
       /*     var toUpdate = await _mediator.Send(new GetCarById { CarId = carId });
            if (toUpdate == null)
            {
                _logger.LogWarning("The Id could not be found");
                return NotFound();
            }
*/
            var command = new UpdateCar
            {
                Id = carId,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
                ImageLink=car.ImageLink,
            };
            _logger.LogInformation("Request with the updated car was sent!");
            var updatedCar = await _mediator.Send(command);
            _logger.LogInformation("The car was updated");
            return Ok(updatedCar);
        }

    }
}
