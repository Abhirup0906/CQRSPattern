using CQRSPattern.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.NoMediatR
{
    public class GetEmployeeHandler : ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeModel> Handle(BaseRequestModel request)
        {
            return _employeeRepository.GetEmployees();
        }
    }
}
