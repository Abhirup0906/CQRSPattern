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
            services.AddScoped<ICommandHandler<BaseResponseModel, EmployeeModel>, CreateEmployeeHandler>()
                .AddScoped(serviceProvider => new Lazy<ICommandHandler<BaseResponseModel, EmployeeModel>>(() => serviceProvider.GetService<ICommandHandler<BaseResponseModel, EmployeeModel>>()));

            services.AddScoped<ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>, GetEmployeeHandler>()
                .AddScoped(serviceProvider => new Lazy<ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>>(()=> serviceProvider.GetService<ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>>()));            

            services.AddMediatR(typeof(DIConfig).Assembly);
        }
    }
}
