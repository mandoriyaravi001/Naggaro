using DataAccessLayer.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventApplicationCore.Models
{
    public class DisplayEventViewModel
    {
        public int EventID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "Duration in hours"), Range(0, 4)]
        public int DurationInHours { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed")]
        public string Description { get; set; }

        [Display(Name = "Other Details")]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters allowed")]
        public string OtherDetails { get; set; }

        [Display(Name = "Total invited to event")]
        public int TotalInvitedToEvent { get; set; }

        public Comment Comment { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
