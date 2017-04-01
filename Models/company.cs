using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    [Table("company")]
    public class company
    {
        [Key]
        public int ID_Compa { get; set; }
        public string Name_Compa { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public ICollection<regis> regis { get; set; }
    }
}