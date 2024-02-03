using Microsoft.EntityFrameworkCore;
using Portal.Infastration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infastration.Database
{
    public partial class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) :base(opt)
        { 

        } 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server =PH99 ;database=PortalDb; Trusted_Connection =True; MultipleActiveResultSets=true; Trust Server Certificate=true;");
        //}
    }
    public partial class ApplicationContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
