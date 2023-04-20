using System.Collections.Generic;
using System.Linq;

namespace BLL_Buisness_Logic_Layer_
{
    public class Events
    {
        private Events objDb;

        public int UserID { get; private set; }
        public string EventsType { get; private set; }
        public object EventDescription { get; private set; }
        public object Event { get; private set; }

        public object EventLocation { get; private set; }
        public object EventOtherDetails { get; private set; }
        public object EventName { get; private set; }
        public object EventStartTime { get; private set; }
        public object EventDate { get; private set; }

        public Events()
        {
            objDb = new Events();
        }
        public IEnumerable<Events> GetAll()
        {
            return objDb.GetAll();
        }
        public Events GetById(int eventid)
        {
            return objDb.GetById(eventid);
        }
        public List<Events> GetList()
        {
            return objDb.GetAll().ToList();
        }
        public void Insert(Events new_event)
        {
            objDb.Insert(new_event);
        }
        public bool Update(Events new_event, int id)
        {
            return objDb.Update(new_event, id);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
        public IEnumerable<Events> GetPublicEvent()
        {
            //for public EventType="public , for private="private"
            var output = GetAll().Where(d => d.EventsType == "Public");
            return output;
        }
        public bool AddEvent(Events new_event)
        {
            if (new_event == null)
            {
                return false;
            }

            if (new_event.EventDate == null || new_event.EventDescription == null || new_event.EventLocation == null || new_event.EventName == null || new_event.EventOtherDetails == null || new_event.EventStartTime == null)
            {
                return false;
            }
            Insert(new_event);
            return true;
        }
        public IEnumerable<Events> GetCreatedEvent(int userID)
        {

            var output = GetList().Where(d => d.UserID == userID);

            return output;
        }

    }
}
