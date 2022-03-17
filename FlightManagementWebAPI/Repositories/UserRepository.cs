using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class UserRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public UserRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }
        public List<User> GetUsers()
        {
            return _airportSystemContext.Users.ToList();
        }
        public void InsertUser(User user)
        {
            _airportSystemContext.Users.Add(user);
            _airportSystemContext.SaveChanges();
        }
        public void LogInUser (int userId)
        {
            var user = _airportSystemContext.Users.FirstOrDefault(user => user.Id == userId);
            if (user != null)
            {
                user.IsLogged = true;

                _airportSystemContext.SaveChanges();
            }
        }
        public void LogOutUser(int userId)
        {
            var user = _airportSystemContext.Users.FirstOrDefault(user => user.Id == userId);
            if (user != null)
            {
                user.IsLogged = false;
                _airportSystemContext.SaveChanges();
            }
        }
      
       
    }
}
