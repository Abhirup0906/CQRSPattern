using CQRSPattern.Library.NoMediatR;
using CQRSPattern.Library.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /*
         * Lazy initialization is added. 
         * For repo level object we can create using Lazy but its not recommendate, instead of this we can use object pooling or singleton etc.
         * Lazy is good for heavy objects like (Database level operation, file operation or httpClient etc.)
         */ 
        private readonly IMediator _mediator;
        private readonly Lazy<ICommandHandler<BaseResponseModel, EmployeeModel>> _createEmployee;
        private readonly Lazy<ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>> _getEmployee;
        public EmployeeController(IMediator mediatr, 
            Lazy<ICommandHandler<BaseResponseModel, EmployeeModel>> createEmployee,
            Lazy<ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel>> getEmployee)
        {
            _mediator = mediatr;
            _createEmployee = createEmployee;
            _getEmployee = getEmployee;
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee()
        {
            return new JsonResult(_getEmployee.Value.Handle(new BaseRequestModel()));
        }

        [HttpGet("GetMediatREmployee")]
        public async Task<IActionResult> GetMediatREmployee()
        {
            return new JsonResult(await _mediator.Send(new BaseRequestModel()));
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody]EmployeeModel employeeModel)
        {
            return new JsonResult(_createEmployee.Value.Handle(employeeModel));
        }

        [HttpPost("CreateMediatREmployee")]
        public async Task<IActionResult> CreateMediatREmployee([FromBody] EmployeeModel employeeModel)
        {
            return new JsonResult(await _mediator.Send(employeeModel));
        }
    }
}
