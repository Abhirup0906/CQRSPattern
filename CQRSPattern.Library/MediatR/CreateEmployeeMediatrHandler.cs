using CQRSPattern.Library.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSPattern.Library.MediatR
{
    public class CreateEmployeeMediatrHandler : IRequestHandler<EmployeeModel, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeMediatrHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        Task<bool> IRequestHandler<EmployeeModel, bool>.Handle(EmployeeModel request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeRepository.CreateEmployee(request));
        }
    }
}
