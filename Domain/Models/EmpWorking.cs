using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EmpWorking
    {
        public int empid { get; set; }
        [ForeignKey(nameof(client))]
        public int?  clientId { get; set; }
        public Client? client { get; set; }
        public DateTime from { get; set; }
        public DateTime To { get; set; }

        
    }
}
