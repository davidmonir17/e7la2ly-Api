using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionsClass
{
    public sealed class BranchNotFoundException : NotfoundException
    {
        public BranchNotFoundException(int branchID) : base($"The branch with id: {branchID} doesn't exist in the database." )
        {
        }
    }
}
