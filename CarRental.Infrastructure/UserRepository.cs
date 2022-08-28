
using CarRental.Application.Repositories;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastrcuture
{
    public class UserRepository:IUserRepository
    {
        private List<User> _users = new List<User>();


        public void CreateUser(User user)
        {
            _users.Add(user);

        }
        public void UpdateUser(User user)
        {
            var toUpdate = _users.FirstOrDefault(u => u.Id == user.Id);
            toUpdate.SetUserUpdate(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }
        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
        public List<User> GetAll()
        {
            return _users;
        }

    }
}
