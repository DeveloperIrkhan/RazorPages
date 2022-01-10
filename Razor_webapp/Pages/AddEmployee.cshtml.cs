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
    public class AddEmployeeModel : PageModel
    {
        private IEmployeeRepo _repo;
        private IWebHostEnvironment _env;

        public AddEmployeeModel(IEmployeeRepo repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }
        public EmployeeModel Employee { get; set; }
        public IFormFile PhotoUpload { get; set; }

        public void OnGet()
        {
        }
        public void OnPost(EmployeeModel employee)
        {
            if (PhotoUpload != null)
            {
                employee.PhotoPath = OnPhotoUpload();
            }
            Employee = _repo.AddEmp(employee);
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
