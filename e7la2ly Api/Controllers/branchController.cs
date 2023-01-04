using Contracts;
using DataTransferObjects.CreationDto;
using e7la2ly_Api.ModelBinders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using e7la2ly_Api.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.Reflection;


namespace e7la2ly_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class branchController : ControllerBase
    {
        private readonly IServiceManager service;

        public branchController(IServiceManager service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getBranches()
        {
            //throw new Exception("Exception");
            var Branches = service.Branch.GetAlBranchess(false);
            return Ok(Branches);

        }
        [HttpGet("{id}",Name ="getBranchById")]
        public IActionResult getBranch(int id)
        {
            var branch=service.Branch.GetBranch(id,false);
            return Ok(branch);  
        }
        [HttpGet("collection/({ids})", Name = "BranchCollection")]
        public IActionResult GetBranchCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var branch = service.Branch.GetAlBrancheCollection(ids, trackChanges: false);
            return Ok(branch);
        }
        [HttpPost]
        public IActionResult CreateBranch([FromBody] BranchCreationDto branch)
        {
            if (branch == null)
            {
                return BadRequest("Branch Object is null");
            }
            var createdBranch=service.Branch.AddBranch(branch);
            return CreatedAtRoute("getBranchById", new { id = createdBranch.branchId }, createdBranch);
        }

        [HttpPost("CreateBranchWithEmployee")]
        public IActionResult CreateBranchWithEmployee([FromBody] BranchWithEmpDto branch)
        {
            if (branch == null)
            {
                return BadRequest("Branch Object is null");
            }
            var createdBranch = service.Branch.AddBranchWithEmp(branch);
            return CreatedAtRoute("getBranchById", new { id = createdBranch.branchId }, createdBranch);
        }
        [HttpPost("collection")]
        public IActionResult CreateCompanyCollection([FromBody] IEnumerable<BranchCreationDto> companyCollection)
        {
            var result =
            service.Branch.CreateCompanyCollection(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids },
            result.companies);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBranch(int id)
        {
            service.Branch.DeleteBranch(id, trackChanges: false);
            return NoContent();
        }


    }
}
