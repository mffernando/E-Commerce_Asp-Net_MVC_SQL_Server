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
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "City")]
        public string Name { get; set; }
        //necessary to build the project (Build > Build Solution)
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Department")]
        [Range(1, double.MaxValue, ErrorMessage = "Select a Department!")]
        public int DepartmentsId { get; set; }

        //relationship in DB
        public virtual Departments Department { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}