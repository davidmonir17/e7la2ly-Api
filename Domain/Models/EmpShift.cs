using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EmpShift
    {
        [Required]
        public int empid { get; set; }
        //public Employee employee { get; set; }
        [Required]
        public DateTime shiftDate { get; set; }

        [Required]
        [ForeignKey(nameof(shift))]
        public int shiftId { get; set; }
        public Shift shift { get; set; }

        

    }
}
