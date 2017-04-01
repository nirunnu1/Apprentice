using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Jobb.Models;
using static Jobb.Models.modelEnum;

namespace Jobb.Models
{
    [Table("meeting")]
    public class meeting
    {
        [Key]
        public int? ID_Mit { get; set; }
        public string Title { get; set; }
        public DateTime Datetime_Start { get; set; }
        public DateTime Datetime_End { get; set; }
        public string LocationType { get; set; }
        public string Detail { get; set; }
        public status? meet_show { get; set; }
        public meetingcase Type { get; set; }

        
    }

}