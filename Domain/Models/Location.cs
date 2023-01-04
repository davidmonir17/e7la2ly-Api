using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Location
    {
        [Key]
        public int locId { get; set; }
        [Required(ErrorMessage = "City Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the City Name is 60 characters.")]
        public string? City  { get; set; }
        [Required(ErrorMessage = "Country Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Country Name is 60 characters.")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "zone Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the zone Name is 60 characters.")]
        public string? zone { get; set; }
        public ICollection<Branch>? branches { get; set; }
        public ICollection<Employee>? employees { get; set; }

    }
}
