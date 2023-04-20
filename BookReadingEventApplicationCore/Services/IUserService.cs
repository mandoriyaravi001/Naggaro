using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        public void RegisterUser(User user);
        public bool Exist(User user);
        public bool Login(User user);
        public int GetUserID(string email);
        public string GetRole(string email);
        public bool IsValidRole(string role);


    }
}
