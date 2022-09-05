using AutoMapper;
using CarRental.Api.Controllers;
using CarRental.Api.DTO;
using CarRental.Application.Users;
using CarRental.Application.Users.Commands;
using CarRental.Application.Users.Queries;
using CarRental.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<UserController>> _mockLogger = new Mock<ILogger<UserController>>();
        [Fact]
        public async Task GetUserById_ShouldReturnUser()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserById>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            //Act
            var controller = new UserController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetById(1);
            //Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetUserById>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task GetById_ShouldReturnTheUserWithCorectId()
        {
            int carId = 0;
            //Arrange
            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetUserById>(), It.IsAny<CancellationToken>()))
              .Returns<GetUserById, CancellationToken>(async (q, c) =>
              {
                  carId = q.UserId;
                  return await Task.FromResult(
                      new User
                      {
                          Id = q.UserId,
                          FirstName = "Theo",
                          LastName = "Nikki",
                          Age = 25,
                          City = "Bucuresti",
                          Email = "teo.nik@gmail.com"

                      });
              });
            var controller = new UserController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            await controller.GetById(1);
            Assert.Equal(carId, 1);
        }
        [Fact]
        public async Task CreateUser_ShouldReturnUserPutPostDto()
        {
            //Arrange
            var createUserDto = new UserPutPostDto
            {
                FirstName = "Theo",
                LastName = "Nikki",
                Age = 25,
                City = "Bucuresti",
                Email = "teo.nik@gmail.com"
            };
            var createUser = new CreateUser
            {
                FirstName = "Theo",
                LastName = "Nikki",
                Age = 25,
                City = "Bucuresti",
                Email = "teo.nik@gmail.com"
            };
            _mockMapper
            .Setup(m => m.Map<CreateUser>(It.Is<UserPutPostDto>(c => c == createUserDto)))
            .Returns(createUser);

            _mockMediator
                .Setup(m => m.Send(It.Is<CreateUser>(s => s == createUser), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    FirstName = "Theo",
                    LastName = "Nikki",
                    Age = 25,
                    City = "Bucuresti",
                    Email = "teo.nik@gmail.com"
                });

            _mockMapper
                .Setup(m => m.Map<UserGetDto>(It.IsAny<User>()))
                .Returns(new UserGetDto
                {
                    FirstName = "Theo",
                    LastName = "Nikki",
                    Age = 25,
                    City = "Bucuresti",
                    Email = "teo.nik@gmail.com"
                });

            var controller = new UserController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            //Act
            var result = controller.CreateUser(createUserDto);
            var okResult = result.Result as OkObjectResult;
            var userGetDto = okResult.Value as UserGetDto;


            //Assert
            Assert.Equal(createUserDto.FirstName, userGetDto.FirstName);
        }

        [Fact]
        public async Task UpdateUser_ShouldChangeUserFields()
        {   //Assemble
            int updateUserId = 1;
            var userToUpdateDto = new UserPutPostDto
            {
                FirstName = "Theo",
                LastName = "Nikki",
                Age = 25,
                City = "Bucuresti",
                Email = "teo.nik@gmail.com"
            };
            var userToUpdate = new UpdateUser
            {
                Id = updateUserId,
                FirstName = "Theo",
                LastName = "Nikki",
                Age = 25,
                City = "Bucuresti",
                Email = "teo.nik@gmail.com"
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateUser>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    Id = updateUserId,
                    FirstName = "Theo",
                    LastName = "Nikki",
                    Age = 25,
                    City = "Bucuresti",
                    Email = "teo.nik@gmail.com"
                });
            var controller = new UserController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);
            
            //Act
            var result = controller.UpdateUser(updateUserId,userToUpdateDto);
            var okResult = result.Result as OkObjectResult;
            var userUpdate = okResult.Value as User;

            //Assert
            Assert.Equal(userToUpdate.Email, userUpdate.Email);
        }
    }
}
