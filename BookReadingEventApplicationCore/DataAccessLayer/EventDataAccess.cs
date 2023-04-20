using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class EventDataAccess : IEventDataAccess
    {
        private readonly EventDataContext eventDataContext;

        public EventDataAccess (EventDataContext eventDataContext)
        {
            this.eventDataContext = eventDataContext;
        }

        // create event
        public void Create(DataAccessLayer.DatabaseModels.Event @event)
        {
            eventDataContext.Event.Add(@event);
            eventDataContext.SaveChanges();
        }

        // Event Valid
        public bool IsNotEventvalid(Event @event)
        {
            var IsValid = eventDataContext.Event.Any(X => X.Title == @event.Title);
            return IsValid;
        }

        // fetch events details
        public Event GetDetails(int id)
        {
            var @event = eventDataContext.Event.Find(id);
            return @event;
        }

        // to  get events by userId
        public IEnumerable<Event> SelectAllEvents(int userID)
        {
            var @event = from e in eventDataContext.Event
                         where (e.UserID == userID)
                         select e;
            return @event;
        }

        //Event match during update
        public bool UpdateExist(Event @event)
        {
            if (eventDataContext.Event.Any(e => e.Title == @event.Title && e.Date == @event.Date &&
             e.Location == @event.Location && e.StartTime == @event.StartTime && e.EventID != @event.EventID))
            {
                return true;
            }
            return false;
        }

        //update event data
        public void Update(Event @event)
        {
            var @oldevent = eventDataContext.Event.Find(@event.EventID);

            @oldevent.Title = @event.Title;
            @oldevent.Date = @event.Date;
            @oldevent.Location = @event.Location;
            @oldevent.StartTime = @event.StartTime;
            @oldevent.Type = @event.Type;
            @oldevent.DurationInHours = @event.DurationInHours;
            @oldevent.Description = @event.Description;
            @oldevent.OtherDetails = @event.OtherDetails;
            @oldevent.InviteByEmail = @event.InviteByEmail;
            oldevent.UserID = @event.UserID;

            eventDataContext.SaveChanges();

        }

        //To delete an event
        public void Delete(int id)
        {
            var @event = eventDataContext.Event.Find(id);
            eventDataContext.Event.Remove(@event);
            eventDataContext.SaveChanges();
        }

        //Is VAlid Edit
        public bool IsValidEdit(int id, int userID)
        {
            if (eventDataContext.Event.Find(id).UserID == userID)
            {
                return true;
            }
            return false;
        }

        //Get all event where user was invited
        public IEnumerable<Event> EventInvitedTo(int userId)
        {
            var email = eventDataContext.User.Find(userId).Email;
            var @events = eventDataContext.Event.
                          Where(e => e.InviteByEmail != null && e.InviteByEmail.Contains(email));
            return @events;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
