
using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Infrastructure;
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
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
           await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

        }
        public void UpdateUser(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }
        public User GetById(int id)
        {
            var user = _context.User.SingleOrDefault(u => u.Id == id);
            return user;
        }
        public List<User> GetByAge(int age)
        {
            var filtredList= _context.User.Where(u => u.Age > age).ToList();
            return filtredList;
        }
        public List<User> GetByCity(string city)
        {
            var cityList= _context.User.Where(u=>u.City==city).ToList();
            return cityList;
        }
        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

    }
}
