using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IEventDataAccess
    {
        public void Create(DataAccessLayer.DatabaseModels.Event @event);
        public bool IsNotEventvalid(Event @event);
        public Event GetDetails(int id);
        public IEnumerable<Event> SelectAllEvents(int userID);
        public bool UpdateExist(Event @event);
        public void Update(Event @event);
        public void Delete(int id);
        public bool IsValidEdit(int id, int userID);
        public IEnumerable<Event> EventInvitedTo(int userId);
        void SaveChanges();
    }
}
