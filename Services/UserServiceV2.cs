using System;
using System.Collections.Generic;
using System.Linq;
using jwt_authentication.Models;

namespace jwt_authentication.Services
{
    public class UserServiceV2 : IUserServiceV2
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test2", LastName = "User2", Username = "test", Password = "test" }
        };

        public User FindByUserName(string username)
        {
          return _users.SingleOrDefault(x => x.Username == username);
        }
    }
}