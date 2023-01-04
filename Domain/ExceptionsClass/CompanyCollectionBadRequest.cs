using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionsClass
{
    public sealed class CompanyCollectionBadRequest : BadRequestException
    {
        public CompanyCollectionBadRequest() : base("Branch collection sent from a client is null.")
        {
        }
    }
}
