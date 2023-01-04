using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class BranchDTO
    {
        public int branchId { get; set; }
        public string? branchName { get; set; }
        public string opiningTime { get; set; }
        public string closeTime { get; set; }      
        public string location { get; set; }
        public int brandId { get; set; }
        public string brand { get; set; }
    }
}
