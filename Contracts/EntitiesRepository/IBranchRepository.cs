using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.EntitiesRepository
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetAllBranches(bool trackChanges);
        Branch GetBranch(int id,bool trackChanges);
        void AddBranch(Branch branch);
        IEnumerable<Branch>getByIds(IEnumerable<int> ids, bool trackChanges);
       void DeleteBranch(Branch branch);


    }
}
