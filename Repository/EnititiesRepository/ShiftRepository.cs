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
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
