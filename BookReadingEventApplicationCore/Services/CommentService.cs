using DataAccessLayer;
using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDataAccess commentDataAccess;
        public CommentService(ICommentDataAccess commentDataAccess)
        {
            this.commentDataAccess = commentDataAccess;
        }

        public void Create(Comment comment)
        {
            DataAccessLayer.DatabaseModels.Comment comment1 = new DataAccessLayer.DatabaseModels.Comment()
            {
                Comments = comment.Comments,
                DateTime = comment.DateTime,
                EventID = comment.EventID
            };
            commentDataAccess.Create(comment1);
        }
    }
}
