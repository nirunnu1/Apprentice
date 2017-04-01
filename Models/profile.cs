using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Jobb.Models.modelEnum;

namespace Jobb.Models
{
    [Table("profile")]
    public class profile
    {
        [Key]
        public int ID { get; set; }
        public int ID_Stu { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        [DataType(DataType.EmailAddress)]
        [DisplayFormat(NullDisplayText = "Email address")]
        [Display(Name = "Email address")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        public sex Sex { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }

        public ICollection<resume> resume { get; set; }
        public ICollection<regis> regis { get; set; }
        public ICollection<supervision> supervision { get; set; }

    }
}