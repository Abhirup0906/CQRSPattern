using CQRSPattern.Library.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.NoMediatR
{
    public class BaseRequestModel: IRequest<IEnumerable<EmployeeModel>>
    {
    }
}
