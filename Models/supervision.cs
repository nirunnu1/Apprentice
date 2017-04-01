using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    [Table("supervision")]
    public class supervision
    {
        [Key]
        public int ID_Sup { get; set; }
        public DateTime Datetime { get; set; }
        public int COCE_D_05 { get; set; }
        public int COCE_T_06 { get; set; }

        public DateTime? Time_D_05 { get; set; }
        public DateTime? Time_T_06 { get; set; }
        [ForeignKey("regis")]
        public int ID_Regis { get; set; }

        public virtual regis regis { get; set; }
        [ForeignKey("profile")]
        public int ID_Pro { get; set; }

        public virtual profile profile { get; set; }
    }
}