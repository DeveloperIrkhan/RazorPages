using DAL.ModelClasses;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_webapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeRepo _repo;
        public IEnumerable<Employees> employees { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IEmployeeRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }
        public string Message { get; set; }

        public void OnGet()
        {
            employees = _repo.GetAllEmployees();
        }
    }
}
