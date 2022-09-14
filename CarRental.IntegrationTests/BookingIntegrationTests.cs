using CarRental.Api.DTO;
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
    public class BookingIntegrationTests
    {
        private static WebApplicationFactory<Program> _factory;
        public BookingIntegrationTests()
        {
            _factory = new CustomWebAplicationFactory<Program>();
        }
        [Fact]
        public async Task GetBookingById_ShoudlReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/booking/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetBookingById_ShouldReturn404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/booking/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetAll_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/booking");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task CreateBooking_ShouldReturnResponse()
        {
            var newBooking = new BookingPutPostDto
            {
                CarId = 2,
                UserId=2,
                StartDate=DateTime.Now,
                EndDate=DateTime.Now
              
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/booking", new StringContent(JsonConvert.SerializeObject(newBooking), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task DeleteBooking_ShouldReturnNoContent()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/booking/1");
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteBooking_ShouldReturn404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/user/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
