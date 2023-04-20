using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUserDataAccess
    {
        public void RegisterUser(User user);
        public bool Exist (User user);
        public bool Login(User user);
        public bool IsValidRole(string role);
        public string GetRole(string email);
        public int GetUserID(string email);

    }
}
