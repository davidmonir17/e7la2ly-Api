using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.EntitiesRepository
{
    public interface IRepositoryManager
    {
        IBranchRepository Branch { get; }
        IBrandRepository Brand { get; }
        IClientRepository Client { get; }
        IEmployeeReopsitory Employee { get; }
        IEmpShiftRepository EmpShift { get; }
        IEmpWorkingRepository EmpWorking { get; }
        ILocationReposetory Location { get; }
        IShiftRepository Shift { get; }
        void save();

    }
}
