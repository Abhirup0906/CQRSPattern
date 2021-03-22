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
        private readonly IMediator _mediator;
        private readonly ICommandHandler<BaseResponseModel, EmployeeModel> _createEmployee;
        private readonly ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel> _getEmployee;
        public EmployeeController(IMediator mediatr, 
            ICommandHandler<BaseResponseModel, EmployeeModel> createEmployee,
            ICommandHandler<IEnumerable<EmployeeModel>, BaseRequestModel> getEmployee)
        {
            _mediator = mediatr;
            _createEmployee = createEmployee;
            _getEmployee = getEmployee;
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee()
        {
            return new JsonResult(_getEmployee.Handle(new BaseRequestModel()));
        }

        [HttpGet("GetMediatREmployee")]
        public async Task<IActionResult> GetMediatREmployee()
        {
            return new JsonResult(await _mediator.Send(new BaseRequestModel()));
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody]EmployeeModel employeeModel)
        {
            return new JsonResult(_createEmployee.Handle(employeeModel));
        }

        [HttpPost("CreateMediatREmployee")]
        public async Task<IActionResult> CreateMediatREmployee([FromBody] EmployeeModel employeeModel)
        {
            return new JsonResult(await _mediator.Send(employeeModel));
        }
    }
}
