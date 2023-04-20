using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Event
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string StartTime { get; set; }

        public string Type { get; set; }

        public int DurationInHours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InviteByEmail { get; set; }

        public int UserID { get; set; }
    }
}
