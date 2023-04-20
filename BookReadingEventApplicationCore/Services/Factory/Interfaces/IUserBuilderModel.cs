using System;
using System.Collections.Generic;
using System.Text;
using Services.Models;

namespace Services.Build_Models.Interfaces
{
    public interface IUserBuilderModel
    {
        DataAccessLayer.DatabaseModels.User BuildModel(User user);
    }
}
