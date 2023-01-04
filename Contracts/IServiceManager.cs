using Contracts.EntitiesRepository;
using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IServiceManager
    {
        IBranchService Branch { get; }
        IBrandService Brand { get; }
        IClientService Client { get; }
        IEmployeeService Employee { get; }
        IEmpShiftService EmpShift { get; }
        IEmpWorkingService EmpWorking { get; }
        ILocationService Location { get; }
        IShiftService Shift { get; }
    }
}
