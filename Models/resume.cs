using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Jobb.Models.modelEnum;

namespace Jobb.Models
{
    [Table("resume")]
    public class resume
    {
        [Key]
        public int ID_Resume { get; set; }
        public double Grade { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public statusprofie Status { get; set; }
        public Nationality Nationality { get; set; }
        public Region Region { get; set; }
        public string Career_Objective { get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
        public string Project { get; set; }
        [ForeignKey("profile")]
        public int ID_Pro { get; set; }

        public virtual profile profile { get; set; }
        public ICollection<regis> regis { get; set; }

    }
}