using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IEventService
    {
        public void Create(Services.Models.Event @event);
        public Event GetDetails(int id);
        public IEnumerable<Event> GetEvents(int userId);
        public bool IsNotValidEvent(Services.Models.Event @event);
        public bool Update(Event @event);
        public void Delete(int id);
        public List<string> EventType();
        public List<string> StartTimelist();
        public bool IsValidEdit(int id, int UserID);
        public IEnumerable<Event> EventInvitedTo(int userId);
        object GetEvents();
    }
}
