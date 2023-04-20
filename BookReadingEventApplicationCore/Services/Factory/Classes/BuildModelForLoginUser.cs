using Services.Build_Models.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Build_Models.Classes
{
    public class BuildModelForLoginUser : IUserBuilderModel
    {
        public DataAccessLayer.DatabaseModels.User BuildModel(User user)
        {
            DataAccessLayer.DatabaseModels.User userData = new DataAccessLayer.DatabaseModels.User()
            {
                Email = user.Email,
                Password = user.Password
            };
            return userData;
        }
    }
}
