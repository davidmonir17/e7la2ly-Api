using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Branch
    {
        [Key]
        public int branchId { get; set; }
        [Required(ErrorMessage = "branch Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the branch Name is 60 characters.")]
        public string? branchName { get; set; }
        [Required(ErrorMessage = "Opening Time is a required field.")]
        //timeonly
        public DateTime opiningTime { get; set; }
        [Required(ErrorMessage = "closing Time is a required field.")]
        public DateTime closeTime { get; set; }
        
        [ForeignKey(nameof(location))]
        public int  locationId { get; set; }
        public Location? location { get; set; }

        [ForeignKey(nameof(brand))]
        public int brandId { get; set; }
        public Brand brand { get; set; }
        public ICollection<Employee>? employees { get; set; }
        public ICollection<Shift>? shifts { get; set; }
    }
}
