using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Portal.Infastration.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [Required ,StringLength(50)]
        public string? Name { get; set; }
        [Required, StringLength(50)]

        public string? Code { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
