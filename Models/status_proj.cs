using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Jobb.Models.modelEnum;

namespace Jobb.Models
{
    [Table("status_proj")]
    public class status_proj
    {
        [Key]
        public int ID_StaProj { get; set; }
        public status RPCE_S_01 { get; set; }
        //public int RPCE_S_02 { get; set; }
        public status RPCE_S_05 { get; set; }
        public status RPCE_T_06 { get; set; }
        public status RPCE_S_08 { get; set; }
        public status RPCE_D_07 { get; set; }
      
        public DateTime? date_S_01 { get; set; }
        public DateTime? date_S_05 { get; set; }
        public DateTime? date_T_06 { get; set; }
        public DateTime? date_S_08 { get; set; }
        public DateTime? date_D_07 { get; set; }



        [ForeignKey("regis")]
        public int ID_Regis { get; set; }

        [ForeignKey("ins")]
        public int ID_ins { get; set; }
        public virtual ins ins { get; set; }
        public virtual regis regis { get; set; }
    }
}