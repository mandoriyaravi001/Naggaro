using Services.Build_Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Utitlties
{
    public class Constant
    {
        public delegate IUserBuilderModel serviceUserBuilderModel(string _serviceTypeForUserModel);
    }
}
