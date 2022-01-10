using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IEmployeeRepo
    {
        public IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel EmployeeDetails(int Id);
        EmployeeModel AddEmp(EmployeeModel AddEmployee);
        EmployeeModel UpdateEmp(EmployeeModel employeeModel);

    }
}
