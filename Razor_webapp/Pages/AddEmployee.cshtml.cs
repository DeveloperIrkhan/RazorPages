using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Razor_webapp.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private IEmployeeRepo _repo;

        public AddEmployeeModel(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public IFormFile Photo { get; set; }
        public EmployeeModel Employee { get; set; }

        public void OnGet()
        {
            
        }
        public void OnPost(EmployeeModel emp)
        {
            Employee = new EmployeeModel()
            {
                Name = emp.Name,
                Address = emp.Address,
                PhoneNo = emp.PhoneNo,
                designation = emp.designation,
                PhotoPath = emp.PhotoPath
            };
            _repo.AddEmp(Employee);
        }
    }
}
