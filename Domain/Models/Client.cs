using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int ClientId { get; set; }
        public string? name { get; set; }
        [ForeignKey(nameof(location))]
        public int locationId { get; set; }
        public Location? location { get; set; }

        public ICollection<EmpWorking>? empWorkings { get; set; }


    }
}
