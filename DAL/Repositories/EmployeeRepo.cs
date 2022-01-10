using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Models;
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

        #region Adding new Employee
        public EmployeeModel AddEmp(EmployeeModel AddEmployee)
        {
            _context.Add(AddEmployee);
            _context.SaveChanges();
            return AddEmployee;
        }
        #endregion

        #region Existing Employee Details
        public EmployeeModel EmployeeDetails(int Id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == Id);
        }
        #endregion

        #region Getting All Records
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return _context.Employees;
        }
        #endregion

        #region updating Existing Employee
        public EmployeeModel UpdateEmp(EmployeeModel updatedEmp)
        {
            EmployeeModel emp = _context.Employees
                                            .FirstOrDefault(
                                               emp => emp.Id == updatedEmp.Id);
            if (emp != null)
            {
                emp.Name = updatedEmp.Name;
                emp.PhoneNo = updatedEmp.PhoneNo;
                emp.PhotoPath = updatedEmp.PhotoPath;
                emp.Address = updatedEmp.Address;
                emp.designation = updatedEmp.designation;
            }
            _context.SaveChanges();
            return emp;

        }
        #endregion
    }
}
