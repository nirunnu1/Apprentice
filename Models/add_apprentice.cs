using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    [Table("add_apprentice")]
    public class add_apprentice
    {
        [Key]
        public int ID_add { get; set; }
        public int Week { get; set; }
        public DateTime Datetime { get; set; }
        public string Work { get; set; }
        public int Type { get; set; }

        [ForeignKey("regis")]
        public int ID_Regis { get; set; }

        public virtual regis regis { get; set; }

    }
}