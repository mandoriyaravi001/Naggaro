using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ICommentService
    {
        public void Create(Comment comment);

    }
}
