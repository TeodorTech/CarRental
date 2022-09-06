using CarRental.Api.DTO;
using CarRental.Application.Users;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.IntegrationTests
{
    public class UserIntegrationtests : IDisposable
    {

        private static WebApplicationFactory<Program> _factory;
        public UserIntegrationtests()
        {
            _factory = new CustomWebAplicationFactory<Program>();
        }

        [Fact]
        public async Task GetById_ShoudlReturnResponse()
        {
           
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/user/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldRetunr404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/user/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task GetAll_ShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/user");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnResponse()
        {
            var newUser = new UserPutPostDto
            {
                FirstName = "Mihai",
                LastName = "Burlacu",
                Age = 25,
                City = "Bucuresti",
                Email = "mihai.burlacu@yahoo.com"
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/user", new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task RemoveUser_ShouldReturnNoContent()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/user/2");
            Assert.True(response.StatusCode== HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task RemoveUser_ShouldReturn404IfNotFound()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/user/45");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task UpdateUser_ShouldReturnResponse()
        {
            var updateUser = new UpdateUser
            {
                FirstName = "Roberto",
                LastName = "Carlos",
                Age = 45,
                City = "Rio",
                Email = "roberto,crlos"
            };
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/user/1", new StringContent(JsonConvert.SerializeObject(updateUser), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdateUser_ShouldReturn404ResponseIfIdNotFound()
        {
            var updateUser = new UpdateUser
            {
                FirstName = "Roberto",
                LastName = "Carlos",
                Age = 45,
                City = "Rio",
                Email = "roberto,crlos"
            };
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/user/45", new StringContent(JsonConvert.SerializeObject(updateUser), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
