using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("EmployeeRecord")]
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "FullName")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "PhonnNumber")]
        public string PhoneNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} required!!!")]
        [Display(Name = "Designation")]
        public Designation designation { get; set; }
        public string PhotoPath { get; set; }

    }
}
