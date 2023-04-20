using DataAccessLayer;
using Services.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public class UnitofWork : IUnitofWork
        
    {
        private readonly IEventDataAccess eventDataAccess;
        private IEventService _EventService;

        public UnitofWork(IEventDataAccess eventDataAccess)
        {
            this.eventDataAccess = eventDataAccess;
        }

        public IEventService EventService 
        {
            get
            {
                return _EventService = _EventService ?? new EventService(eventDataAccess);

            }
        }

        public void Save()
        {
            // throw new NotImplementedException();
            eventDataAccess.SaveChanges();
        }
    }
}
