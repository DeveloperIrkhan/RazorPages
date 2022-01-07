using DAL.DbContexts;
using DAL.ModelClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employees> GetAllEmployees()
        {
            return _context.EmployeesInfo;
        }
    }
}
