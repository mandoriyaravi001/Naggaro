using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Factory.Interfaces
{
   public interface IUnitofWork
    {
        IEventService EventService { get; }
        void Save();
    }
}
