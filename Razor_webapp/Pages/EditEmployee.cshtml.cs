using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Razor_webapp.Pages
{
    public class EditEmployeeModel : PageModel
    {
        private readonly IEmployeeRepo _repo;
        private readonly IWebHostEnvironment _env;

        public EditEmployeeModel(IEmployeeRepo repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public EmployeeModel employee { get; set; }

        [BindProperty]
        public IFormFile PhotoUpload { get; set; }
        public IActionResult OnGet(int id)
        {
            employee = _repo.EmployeeDetails(id);
            if (employee == null)
            {
                return RedirectToPage("/Shared/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(EmployeeModel employee)
        {
            if (PhotoUpload != null)
            {
                //this code check if photo is already exist, it will delete old one
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_env.WebRootPath, "Images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = OnPhotoUpload();
            }
            employee = _repo.UpdateEmp(employee);
            return RedirectToPage("/Index");
        }
        //this code is for uploading new Photo over Existing Photo;
        private string OnPhotoUpload()
        {
            string UniqueFileName = null;
            if (PhotoUpload != null)
            {
                string UploadFolder = Path.Combine(_env.WebRootPath, "Images");
                UniqueFileName = Guid.NewGuid().ToString() + "" + PhotoUpload.FileName;
                string FilePath = Path.Combine(UploadFolder, UniqueFileName);
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    PhotoUpload.CopyTo(fileStream);
                }
            }
            return UniqueFileName;
        }

    }
}
