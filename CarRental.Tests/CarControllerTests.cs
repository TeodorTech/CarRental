using AutoMapper;
using CarRental.Api.Controllers;
using CarRental.Api.DTO;
using CarRental.Application.Cars.Queries;
using CarRental.Application.Commands;
using CarRental.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests
{
    public class CarControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        [Fact]
        public async Task GetCarById_ShouldReturnCar()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            //Act
            var controller = new CarController(_mockMediator.Object,_mockMapper.Object);
            await controller.GetCarById(2);
            //Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()), Times.Once());
        }
        [Fact]
        public async Task GetCarById_ShouldReturnTheCarWithCorectId()
        {
            int carId = 0;
            //Arrange
            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetCarById>(), It.IsAny<CancellationToken>()))
              .Returns<GetCarById, CancellationToken>(async (q, c) =>
              {
                  carId = q.CarId;
                  return await Task.FromResult(
                      new Car
                      {
                          Id = q.CarId,
                          Make = "Skoda",
                          Model = "Octavia",
                          Year = 2016,
                          PricePerDay = 200

                      });
              });
            var controller = new CarController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetCarById(2);
            Assert.Equal(carId, 2);
        }



        [Fact]
        public async Task CallPost_ShouldReturnCarPutPostDto()
        {
            //Arrange
            var createCarDto = new CarPutPostDto
            {
                Make = "Skoda",
                Model = "Octavia",
                Year = 2016,
                PricePerDay = 200
            };
            var createCar = new CreateCar
            {
                Make = "Skoda",
                Model = "Octavia",
                Year = 2016,
                PricePerDay = 200
            };
            _mockMapper
            .Setup(m => m.Map<CreateCar>(It.Is<CarPutPostDto>(c => c == createCarDto)))
            .Returns(createCar);

            _mockMediator
                .Setup(m => m.Send(It.Is<CreateCar>(s => s == createCar), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Car
                {
                    Make = "Skoda",
                    Model = "Octavia",
                    Year = 2016,
                    PricePerDay = 200
                });
        
            _mockMapper
                .Setup(m=>m.Map<CarGetDto>(It.IsAny<Car>()))
                .Returns(new CarGetDto
                {
                   
                    Make = "Skoda",
                    Model = "Octavia",
                    Year = 2016,
                    PricePerDay = 200
                });

            var controller = new CarController(_mockMediator.Object, _mockMapper.Object);
            //Act
            var result = controller.CreateCar(createCarDto);
            var OkResult = result.Result as OkObjectResult;

            var carGetDto = OkResult.Value as CarGetDto;
            

            //Assert
            Assert.Equal(createCarDto.Make,carGetDto.Make);
        }
    }
}
