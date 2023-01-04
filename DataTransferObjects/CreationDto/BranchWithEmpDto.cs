using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.CreationDto
{
    public class BranchWithEmpDto
    {
        public BranchCreationDto branch { get; set; }
        public IEnumerable<EmployeeForCreationDto> emps { get; set; }


    }
}
