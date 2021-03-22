using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.Repository
{
    public interface IEmployeeRepository
    {
        bool CreateEmployee(EmployeeModel employeeModel);
        IEnumerable<EmployeeModel> GetEmployees();
    }
}
