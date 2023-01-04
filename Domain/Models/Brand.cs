using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Brand
    {
        [Key]
        public int brandID { get; set; }
        [Required(ErrorMessage = "brand Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the brand Name is 60 characters.")]
        public string? brandName { get; set; }
        public int numBranches { get; set; }
        public decimal Rate { get; set; }
        
        public ICollection<Branch>? branches { get; set; }


    }
}
