using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiCRUD.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}