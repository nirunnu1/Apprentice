using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    [Table("regis")]
    public class regis
    {
        [Key]
        public int ID_Regis { get; set; }
        // public int ID_Compa { get; set; }
        //  public int ID_Resume { get; set; }
        // public int ID_Pro { get; set; }
        public int type { get; set; }
        [ForeignKey("profile")]
        public int ID_Pro { get; set; }
       
        public virtual profile profile { get; set; }

        [ForeignKey("company")]
        public int ID_Compa { get; set; }
       
        public virtual company company { get; set; }

        [ForeignKey("resume")]
        public int ID_Resume { get; set; }

        public virtual resume resume { get; set; }
        public ICollection<add_apprentice> add_apprentice { get; set; }
        public ICollection<status_proj> status_proj { get; set; }
        public ICollection<status_coop> status_coop { get; set; }
        public ICollection<supervision> supervision { get; set; }
    }
}