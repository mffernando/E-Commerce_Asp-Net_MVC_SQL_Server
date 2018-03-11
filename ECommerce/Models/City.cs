using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class City
    {
        //prop 2 times tab (auto)
        [Key] //primary key
        public int CityId { get; set; }
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        public string Name { get; set; }
        //necessary to build the project (Build > Build Solution)
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        public int DepartmentsId { get; set; }

        //relationship in DB between department and city
        public virtual Departments Department { get; set; }
    }
}