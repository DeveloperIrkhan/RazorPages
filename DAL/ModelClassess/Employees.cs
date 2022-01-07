using Razor_webapp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.ModelClasses
{
    [Table("EmployeeRecord")]
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name ="Id")] 
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "FullName")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "PhonnNumber")] 
        public string PhoneNo { get; set; } = string.Empty;
        [Required (ErrorMessage = "{0} required!!!")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "Department")]
        public Departments Departments { get; set; }
    }
}
