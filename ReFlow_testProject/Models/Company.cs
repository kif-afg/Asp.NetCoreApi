using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReFlow_testProject.Models
{
    public class Company
    {
        public int companyId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }


        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Owner> Owner { get; set; }

    }
}
