using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReFlow_testProject.Models;

namespace ReFlow_testProject.Models
{
    public class ReFlow_testProjectContext : DbContext
    {
        public ReFlow_testProjectContext (DbContextOptions<ReFlow_testProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ReFlow_testProject.Models.Company> Company { get; set; }

        public DbSet<ReFlow_testProject.Models.Owner> Owner { get; set; }
    }
}
