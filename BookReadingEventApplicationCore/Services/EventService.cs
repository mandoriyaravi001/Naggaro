using DataAccessLayer;
using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class EventService : IEventService
    {
        private readonly IEventDataAccess eventDataAccess;

        public EventService(IEventDataAccess eventDataAccess)
        {
            this.eventDataAccess = eventDataAccess;
        }

        // create event
        public void Create(Services.Models.Event @event)
        {
            DataAccessLayer.DatabaseModels.Event @event1 = new DataAccessLayer.DatabaseModels.Event()
            {
                Title = @event.Title,
                Date = @event.Date,
                Location = @event.Location,
                StartTime = @event.StartTime,
                Type = @event.Type,
                Description = @event.Description,
                OtherDetails = @event.OtherDetails,
                InviteByEmail = @event.InviteByEmail,
                UserID = @event.UserID
              
            };
            eventDataAccess.Create(@event1);
        }

        //To fetch event details
        public Event GetDetails(int id)
        {
            return eventDataAccess.GetDetails(id);
        }

        //to get all events using userId
        public IEnumerable<Event> GetEvents(int userId)
        {
            return eventDataAccess.SelectAllEvents(userId);
        }

        // VAlidate event
        public bool IsNotValidEvent(Services.Models.Event @event)
        {
            DataAccessLayer.DatabaseModels.Event eventData = new DataAccessLayer.DatabaseModels.Event()
            {
                Title = @event.Title
            };
            return eventDataAccess.IsNotEventvalid(eventData);
        }

        //To Edit event
        public bool Update(Event @event)
        {
            if (eventDataAccess.UpdateExist(@event))
            {
                return false;
            }
            eventDataAccess.Update(@event);
            return true;
        }

        //To delete an event
        public void Delete(int id)
        {
            eventDataAccess.Delete(id);
        }

        // Event Type
        public List<string> EventType()
        {
            List<string> Type = new List<string>() { "public", "private" };
            return Type;
        }
        // event startTime list Dropdown
        public List<string> StartTimelist()
        {
            List<string> StartTime = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                {
                    StartTime.Add("0" + i + ":00");
                }
                else
                {
                    StartTime.Add(i + ":00");
                }
            }
            return StartTime;
        }

        // Is Valid Edit
        public bool IsValidEdit(int id, int UserID)
        {
            return eventDataAccess.IsValidEdit(id, UserID);
        }

        //Get all event where user was invited
        public IEnumerable<Event> EventInvitedTo(int userId)
        {
            var @event = eventDataAccess.EventInvitedTo(userId);
            return @event;
        }

        public object GetEvents()
        {
            throw new NotImplementedException();
        }
    }
}
