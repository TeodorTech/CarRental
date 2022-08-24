using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Repositories
{
   public interface IUserRepository
    {
        public void CreateUser(User user);
        
        public void Delete(string firstName);

        public User GetById(int id);
        public List<User> GetAll();
       
    }
}
