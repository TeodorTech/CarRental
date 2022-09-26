using CarRental.Api.DTO;
using CarRental.Application.Cars.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.IntegrationTests
{
    public class CarIntegretionTests
    {
        private static WebApplicationFactory<Program> _factory;
        public CarIntegretionTests()
        {
            _factory = new CustomWebAplicationFactory<Program>();
        }

        [Fact]
        public async Task GetCarById_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/car/2");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetCarById_ShouldRetunr404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/car/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/car/getallcars");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task CreateCar_ShouldReturnResponse()
        {
            var newCar = new CarPutPostDto
            {
                Make = "Audi",
                Model = "R8",
                Year = 2008,
                PricePerDay = 300,
                ImageLink= "img.jpg"
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/car", new StringContent(JsonConvert.SerializeObject(newCar), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteCar_ShouldReturnNoResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/car/2");
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task DeleteCar_ShouldReturn404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/car/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task UpdateCar_ShouldReturnResponse()
        {
            
            var updateCar = new UpdateCar
            {
                
                Make = "Audi",
                Model = "R8",
                Year = 2008,
                PricePerDay = 300,
                ImageLink="image.jpg"
            };
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/car/1", new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task UpdateCar_ShouldReturn404IfIdNotFound()
        {

            var updateCar= new UpdateCar
            {
                Make = "Audi",
                Model = "R8",
                Year = 2008,
                PricePerDay = 300,
                ImageLink = "image.jpg"
            };
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/car/100", new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }


        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
