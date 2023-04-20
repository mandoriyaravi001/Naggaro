using DataAccessLayer;
using Services.Build_Models.Interfaces;
using Services.Models;
using System;
using static Services.Utitlties.Constant;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess userDataAccess;
      //  private readonly IUserBuilderModel LoginuserBuilderModel;
       // private readonly IUserBuilderModel RegisteruserBuilderModel;
        //private readonly IUserBuilderModel ExistuserBuilderModel;
        private readonly serviceUserBuilderModel _serviceUserBuilderModel1;
        public UserService(IUserDataAccess userDataAccess,serviceUserBuilderModel serviceUserBuilderModel)
        {
            this.userDataAccess = userDataAccess;
         //   this.LoginuserBuilderModel = serviceUserBuilderModel("Login");
          //  this.RegisteruserBuilderModel = serviceUserBuilderModel("Register");
           // this.ExistuserBuilderModel = serviceUserBuilderModel("Exist");
            this._serviceUserBuilderModel1 = serviceUserBuilderModel;
        }

        // user register and email exist or not.
        public bool Exist(User user)
        {
            IUserBuilderModel UserModel = _serviceUserBuilderModel1("Exist");
         DataAccessLayer.DatabaseModels.User userEmail = UserModel.BuildModel(user);

            return userDataAccess.Exist(userEmail);
        }

        public void RegisterUser(User user)
        {
            IUserBuilderModel UserModel = _serviceUserBuilderModel1("Register");
            DataAccessLayer.DatabaseModels.User userData = UserModel.BuildModel(user);
            userDataAccess.RegisterUser(userData);

        }

        //Is valid user for login or not
        public bool Login(User user)
        {
            IUserBuilderModel UserModel = _serviceUserBuilderModel1("Login");
            DataAccessLayer.DatabaseModels.User userData = UserModel.BuildModel(user);

            return userDataAccess.Login(userData);
        }

        // GetUserID of user
        public int GetUserID(string email)
        {
            return userDataAccess.GetUserID(email);
        }

        //To Get Roles
        public string GetRole(string email)
        {
            return userDataAccess.GetRole(email);
        }

        // IS Valid Role
        public bool IsValidRole(string role)
        {
            return userDataAccess.IsValidRole(role);
        }
    }
}
