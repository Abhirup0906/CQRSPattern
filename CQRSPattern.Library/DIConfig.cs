using CQRSPattern.Library.NoMediatR;
using CQRSPattern.Library.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MediatR.Registration;

namespace CQRSPattern.Library
{
    public static class DIConfig
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICommandHandler<BaseResponseModel, EmployeeModel>, CreateEmployeeHandler>();
            services.AddScoped<ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>, GetEmployeeHandler>();

            services.AddMediatR(typeof(DIConfig).Assembly);
        }
    }
}
