using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infastration.Entity
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public Guid id { get; set; }
        [StringLength(50)]
        public string ?Name { get; set; }

        public double  Salary { get; set; }

        public string ?Email{ get; set; }
        public string ?Adrress { get; set; }

        public string ?Note { get; set; }
        public DateTime ?HireDate { get; set; }
        public DateTime ?CreateOn { get; set; }

        public DateTime ?UpdateOn { get; set; }
        public DateTime ?DeleteOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsUpdated { get; set; }

        public int DepartmentID { get; set; }
        public Department? department { get; set; }


    }
}
