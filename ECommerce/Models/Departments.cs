using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Departments
    {
        //prop 2 times tab (auto)
        [Key] //primary key
        public int DepartmentsId { get; set; }
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        public string Name { get; set; }
        //necessary to build the project (Build > Build Solution)
    }
}