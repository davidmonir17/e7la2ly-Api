using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        [Key]
        public int empid { get; set; }
        [Required(ErrorMessage = "Employee Name is a required field.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Employee Name is 150 characters.")]
        public string? name { get; set; }
        [Required(ErrorMessage = "National Id is a required field.")]
        [MaxLength(14, ErrorMessage = "Maximum length for the Employee National Id is 14 characters.")]
        public int nationalId { get; set; }
        public int age { get; set; }
      
        [ForeignKey(nameof(branch))]
        public int branchId { get; set; }
        public Branch? branch { get; set; }
        [ForeignKey(nameof(location))]
        public int? locId { get; set; }
        public Location? location { get; set; }
        public ICollection<EmpShift> EmpShifts { get; set; }



    }
}
