using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Shift
    {
        [Key]
        public int shiftId { get; set; }
        [Required]
        public string? shiftName { get; set; }
        [Required]
        //timeonly
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        [ForeignKey(nameof(branch))]
        public int branchId { get; set; }
        public Branch branch { get; set; }
        public ICollection<EmpShift> EmpShifts { get; set; }

    }
}
