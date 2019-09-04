using System;
using jwt_authentication.Models;

namespace jwt_authentication.Services
{
  public interface IUserServiceV2
    {
        User FindByUserName(string username);
    }
}