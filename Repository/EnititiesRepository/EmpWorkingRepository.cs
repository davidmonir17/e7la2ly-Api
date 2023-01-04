using Contracts.EntitiesRepository;
using Domain.DatabaseContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EnititiesRepository
{
    public class EmpWorkingRepository : RepositoryBase<EmpWorking>, IEmpWorkingRepository
    {
        public EmpWorkingRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
