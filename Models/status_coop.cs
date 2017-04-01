using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Jobb.Models.modelEnum;

namespace Jobb.Models
{
    [Table("status_coop")]
    public class status_coop
    {
        [Key]
        public int ID_StaCoop { get; set; }
        public status COCE_C_01 { get; set; }
        public status COCE_S_02 { get; set; }
        public status COCE_SC_03 { get; set; }
        public status COCE_C_07 { get; set; }
        public status COCE_C_08 { get; set; }
        public DateTime? date_C_01 { get; set; }
        public DateTime? date_S_02 { get; set; }
        public DateTime? date_SC_03 { get; set; }
        public DateTime? date_C_07 { get; set; }
        public DateTime? date_C_08 { get; set; }
      

        [ForeignKey("regis")]
        public int ID_Regis { get; set; }

        public virtual regis regis { get; set; }

       

    }


}