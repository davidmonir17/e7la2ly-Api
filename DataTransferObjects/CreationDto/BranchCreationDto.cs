using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.CreationDto
{
    public class BranchCreationDto
    {
        //public int branchId { get; set; }
        public string  branchName { get; set; }
        public string   opiningTime { get; set; }
        public string   closeTime { get; set; }
        public int      locationId { get; set; }
        public int      brandId { get; set; }
    }
}
