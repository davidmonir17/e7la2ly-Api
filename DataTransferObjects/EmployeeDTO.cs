using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class EmployeeDTO
    {
        public int empid { get; set; }
       
        public string name { get; set; }
       
        public int nationalId { get; set; }
        public int age { get; set; }
        public int branchId { get; set; }
        public string location { get; set; }
    }
}
