using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Departments
    {
        //prop 2 times tab (auto)
        [Key] //primary key
        [Display(Name = "Department")]
        public int DepartmentsId { get; set; }
        [MaxLength(50, ErrorMessage = "Max 50 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Name")]
        [Index("Department_Name_Index", IsUnique = true)] // don't allow duplicate names
        public string Name { get; set; }
        //necessary to build the project (Build > Build Solution)

        //relationship in DB between department and city
        public virtual ICollection<City> Cities { get; set; }
    }
}