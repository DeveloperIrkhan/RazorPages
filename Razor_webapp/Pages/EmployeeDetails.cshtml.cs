using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Razor_webapp.Pages
{
    public class EmployeeDetailsModel : PageModel
    {
        private IEmployeeRepo _repo;

        public EmployeeDetailsModel(IEmployeeRepo repo)
        {
            _repo = repo;
        }

        public EmployeeModel EmployeeModel { get; private set; }

        public IActionResult OnGet(int id)
        {
            EmployeeModel = _repo.EmployeeDetails(id);
            if (EmployeeModel == null)
            {
                return RedirectToPage("/Shared/NotFound");
            }
            else
                return Page();
        }
    }
}
