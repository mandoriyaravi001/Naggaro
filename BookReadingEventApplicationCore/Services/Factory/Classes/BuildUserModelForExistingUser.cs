using Services.Build_Models.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Build_Models.Classes
{
   public  class BuildUserModelForExistingUser : IUserBuilderModel
    {
        public DataAccessLayer.DatabaseModels.User BuildModel(User user)
        {
            DataAccessLayer.DatabaseModels.User userEmail = new DataAccessLayer.DatabaseModels.User()
            {
                Email = user.Email
            };
            return userEmail;

        }
    }
}
