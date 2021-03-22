using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<EmployeeModel> employees = new List<EmployeeModel>() {
            new EmployeeModel() { Id=Guid.NewGuid(), DOB=DateTime.Now, Name=$"Name{DateTime.Now.ToString("hh mm ss")}" },
            new EmployeeModel() { Id=Guid.NewGuid(), DOB=DateTime.Now, Name=$"Name{DateTime.Now.ToString("hh mm ss")}" }
        };
        public bool CreateEmployee(EmployeeModel employeeModel)
        {
            employees.Add(employeeModel);
            return true;
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return employees;
        }
    }
}
