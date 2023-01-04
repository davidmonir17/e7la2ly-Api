using Contracts;
using DataTransferObjects.CreationDto;
using DataTransferObjects.UpdateDto;
using Domain.ExceptionsClass;
using e7la2ly_Api.FilterActions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace e7la2ly_Api.Controllers
{
    [Route("api/branch/{branchid}/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public IActionResult getEmployees(int branchid)
        {
            var employees = _serviceManager.Employee.getAllEmployees(branchid, false);
           return Ok( employees);
        }
        [HttpGet("{empid}",Name ="GetEmployeFotBranch")]
        public IActionResult getEmployee(int branchid,int empid)
        {
            var emp = _serviceManager.Employee.GetEmployee(branchid, empid, false);
            return Ok(emp);
        }
        [HttpPost]
        [ServiceFilter(typeof(ActionFilterExample))]
        public IActionResult AddEmployeeAtBranch(int branchid,[FromBody] EmployeeForCreationDto employee )
        {
           // if(employee == null)
            //{
            //    BadRequest("Employee object is null");
            //}
            //if (!ModelState.IsValid)
            //    return UnprocessableEntity(ModelState);
            var empDto = _serviceManager.Employee.CreateEmployeeForbranch(branchid, employee, false);
            return CreatedAtRoute("GetEmployeFotBranch", new { branchid, empDto.empid }, empDto);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeForBranch(int branchid, int id)
        {
            _serviceManager.Employee.DeleteEmployeeForBranch(branchid, id, trackChanges:
            false);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeForCompany(int branchid, int id,[FromBody] EmployeeUpdateDTO employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForUpdateDto object is null");
            _serviceManager.Employee.UpdateEmployeeForBranch(branchid, id, employee,branTrackChanges: false, empTrackChanges: true);
            return NoContent();
        }

    }
}
