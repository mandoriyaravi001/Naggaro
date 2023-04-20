using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface ICommentDataAccess
    {
        public void Create(Comment comment);

    }
}
