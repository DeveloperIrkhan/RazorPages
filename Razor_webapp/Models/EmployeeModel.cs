using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_webapp.Models
{
    public class EmployeeModel
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string PhoneNo { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string Departments { get; set; }
    }
}
