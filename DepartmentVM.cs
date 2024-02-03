using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Models
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Department name Required")]
        [MinLength(2,ErrorMessage = "Min Lenght 2")]
        [MaxLength(50, ErrorMessage = "Max lenght 50")]


        public string? Name { get; set; }
        [Required(ErrorMessage = "Department Code Required")]
        [MinLength(2, ErrorMessage = "Min Lenght 2")]
        [MaxLength(50, ErrorMessage = "Max lenght 50")]

        public string? Code { get; set; }
    }
}
