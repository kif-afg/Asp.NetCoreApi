using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReFlow_testProject.Models
{
    public class Owner
    {
        public int id { get; set; }
        [Required]
        public int cID { get; set; }
        public string cOwner { get; set; }

        [ForeignKey("cID")]
        public Company Company { get; set; }
    }
}
