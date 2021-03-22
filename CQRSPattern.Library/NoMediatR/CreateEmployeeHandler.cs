using CQRSPattern.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.NoMediatR
{
    public class CreateEmployeeHandler : ICommandHandler<BaseResponseModel, EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public BaseResponseModel Handle(EmployeeModel request)
        {
            return new BaseResponseModel() { IsSuccess = _employeeRepository.CreateEmployee(request) };
        }
    }
}
