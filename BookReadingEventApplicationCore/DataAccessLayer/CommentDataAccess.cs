using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class CommentDataAccess : ICommentDataAccess
    {
        private readonly EventDataContext db;

        public CommentDataAccess(EventDataContext db)
        {
            this.db = db;
        }

        public void Create(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();
        }
    }
}
