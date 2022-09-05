
using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastrcuture
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(DataContext context,ILogger<UserRepository> logger)
        {
            _logger=logger;
            _context = context;
        }

        public async Task CreateUser(User user)
        {
           await _context.User.AddAsync(user);
        }
        public async Task UpdateUser(User user)
        {
           _context.User.Update(user);
        }

        public void Delete(User user)
        {
            _context.User.Remove(user);
        }
        public User GetById(int id)
        {
            var user = _context.User.SingleOrDefault(u => u.Id == id);
            _logger.LogInformation($"The user with ID {id} was retrived");
            return user;
        }
        public List<User> GetByAge(int age)
        {
            var filtredList= _context.User.Where(u => u.Age > age).ToList();
            _logger.LogInformation($"The list of users with age higher than {age} has been retrived");
            return filtredList;
        }
        public List<User> GetByCity(string city)
        {
            var cityList= _context.User.Where(u=>u.City==city).ToList();
            _logger.LogInformation($"The list of user who live in {city} has been retrived");
            return cityList;
        }
        public List<User> GetAll()
        {
            _logger.LogInformation($"The list of users has been retrived");
            return _context.User.ToList();
        }

    }
}
