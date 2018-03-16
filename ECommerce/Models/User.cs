using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        //prop 2 times tab (auto)
        //Company ID
        [Key] //primary key
        [Display(Name = "User")]
        public int UserId { get; set; }

        //UserName (E-mail)
        [MaxLength(250, ErrorMessage = "Max 250 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)] //e-mail validation
        [Index("User_UserName_Index", IsUnique = true)] // don't allow duplicate names
        public string UserName { get; set; }

        //User First Name
        [MaxLength(50, ErrorMessage = "Max 50 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //User Last Name
        [MaxLength(50, ErrorMessage = "Max 50 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //User Phone
        [MaxLength(50, ErrorMessage = "Max 50 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)] //telephone validation
        public string Phone { get; set; }

        //User Address
        [MaxLength(100, ErrorMessage = "Max 100 characters!")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        [Display(Name = "Address")]
        public string Address { get; set; }

        //User photo
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)] //imagem validation
        public string Photo { get; set; }

        //Company Logo File
        [NotMapped] //don't include in DB
        public HttpPostedFileBase PhotoFile { get; set; }

        //Department ID
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        public int DepartmentsId { get; set; }

        //City ID
        [Display(Name = "City")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        public int CityId { get; set; }

        //Company ID
        [Display(Name = "Company")]
        [Required(ErrorMessage = "Required {0}!")] //required with error message // {0} field name
        public int CompanyId { get; set; }

        //Full name
        [Display(Name = "User")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        //necessary to build the project (Build > Build Solution)

        //relationship in DB
        public virtual Departments Departments { get; set; }
        public virtual City Cities { get; set; }
        public virtual Company Companies { get; set; }
    }
}