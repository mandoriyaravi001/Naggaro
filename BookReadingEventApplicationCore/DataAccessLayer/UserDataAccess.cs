using DataAccessLayer.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly EventDataContext eventDataContext;

        public UserDataAccess(EventDataContext eventDataContext)
        {
            this.eventDataContext = eventDataContext;
        }

        //Valid Roles
        private List<string> validRoles = new List<string>
        {
            "Admin"
        };

        //Added Roles
        public Dictionary<string,string> AddedRoles()
        {
            Dictionary<string, string> roles = new Dictionary<string, string>
            {
                {"myadmin@bookevents.com" , "Admin" }
            };
            return roles;
        }

        //Get Keys of various Roles
        public List<string> Keys()
        {
            var keys = new List<string>(AddedRoles().Keys);
            return keys;
        }

        //Login user
        public bool Login(DataAccessLayer.DatabaseModels.User user)
        {
            var isValid = eventDataContext.User.Any(x => x.Email == user.Email && x.Password == user.Password);
            return isValid;
        }

        // register user logic and Email exist or not.
        public bool Exist(DataAccessLayer.DatabaseModels.User user)
        {
            if (eventDataContext.User.Any(x => x.Email == user.Email))
            {
                return true;
            }
            return false;
        }
        public void RegisterUser(DataAccessLayer.DatabaseModels.User user)
        {
            eventDataContext.User.Add(user);
            eventDataContext.SaveChanges();
        }

        //To GetUserID of user
        public int GetUserID(string email)
        {
            var user = eventDataContext.User.Where(u => u.Email == email).First().UserID;
           
            return user;
        }

        //Get various Roles
        public string GetRole(string email)
        {
            var roles = AddedRoles();
            var keys = Keys();
            var selectedkey = (from k in keys
                               where (email.Contains(k))
                               select k).FirstOrDefault();
            if (!string.IsNullOrEmpty(selectedkey))
            {
                var value = roles[selectedkey];
                return value;
            }
            return "User";
        }

        //Validate Role for Authentication and Edit
        public bool IsValidRole(string role)
        {
            if(validRoles.Any(v => v == role))
            {
                return true;
            }
            return false;
        }
    }
}
