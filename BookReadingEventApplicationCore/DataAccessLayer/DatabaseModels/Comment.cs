using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.DatabaseModels
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int EventID { get; set; }

        public virtual Event Event { get; set; }
    }
}
