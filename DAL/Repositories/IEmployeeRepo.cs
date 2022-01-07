using DAL.ModelClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employees> GetAllEmployees();
    }
}
