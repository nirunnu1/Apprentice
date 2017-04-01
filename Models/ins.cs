using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    [Table("ins")]
    public class ins
    {
        [Key]
        public int ID_ins { get; set; }
        [ForeignKey("profile")]
        public int Stu_ID { get; set; }
        [ForeignKey("profile1")]

        public int Ins_ID { get; set; }
        public virtual profile profile { get; set; }
        //[ForeignKey("profile")]
        //public int Ins_ID { get; set; }

        public virtual profile profile1 { get; set; }

        public int Type { get; set; }
        public ICollection<status_proj> status_proj { get; set; }
    }
}