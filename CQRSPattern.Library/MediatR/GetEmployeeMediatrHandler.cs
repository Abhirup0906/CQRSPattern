using CQRSPattern.Library.NoMediatR;
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
    public class GetEmployeeMediatrHandler : IRequestHandler<BaseRequestModel, IEnumerable<EmployeeModel>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeeMediatrHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task<IEnumerable<EmployeeModel>> Handle(BaseRequestModel request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_employeeRepository.GetEmployees());
        }
    }
}
