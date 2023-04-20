using System.Collections.Generic;

namespace BLL_Buisness_Logic_Layer_
{
    public class Comments
    {
        private Comments objDb;
        public Comments()
        {
            objDb = new Comments();
        }
        public IEnumerable<Comments> GetAll()
        {
            return objDb.GetAll();
        }
        public Comments GetById(int id)
        {
            return objDb.GetById(id);
        }
        public void Insert(Comments Comment)
        {
            objDb.Insert(Comment);
        }
        public void Update(Comments Comment)
        {
            objDb.Update(Comment);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
    }
}
