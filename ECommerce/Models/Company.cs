using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        //prop 2 times tab (auto)
        //Company ID
        [Key] //primary key
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        //Company Name
        [MaxLength(50, ErrorMessage = "Max 50 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Name")]
        [Index("Company_Name_Index", IsUnique = true)] // don't allow duplicate names
        public string Name { get; set; }

        //Company Phone
        [MaxLength(50, ErrorMessage = "Max 50 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Phone")]
        //[Index("Company_Name_Index", IsUnique = true)] // don't allow duplicate names
        [DataType(DataType.PhoneNumber)] //telephone validation
        public string Phone { get; set; }

        //Company Address
        [MaxLength(100, ErrorMessage = "Max 100 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Address")]
        [DataType(DataType.PhoneNumber)] //telephone validation
        public string Address { get; set; }

        //Company Logo
        [Display(Name = "Logo")]
        [DataType(DataType.ImageUrl)] //imagem validation
        public string Logo { get; set; }

        //necessary to build the project (Build > Build Solution)

        //relationship in DB
        public virtual Departments Departments { get; set; }
        public virtual City Cities { get; set; }
    }
}