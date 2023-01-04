using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionsClass
{
    public class EmployeeNotFoundException : NotfoundException
    {
        public EmployeeNotFoundException(int employeeId)
            : base($"Employee with id: {employeeId} doesn't exist in the database.")
        {
        }

    }
}
