using Contracts;
using Contracts.EntitiesRepository;
using Domain.DatabaseContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EnititiesRepository
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public void AddBranch(Branch branch)
        {
            Create(branch);
        }

        public void DeleteBranch(Branch branch)
        {
            Delete(branch);
        }

        public IEnumerable<Branch> GetAllBranches(bool trackChanges)
        {
          return FindAll(trackChanges).Include(x=>x.location).Include(c=>c.brand).OrderBy(x=>x.branchId).ToList();
        }

        public Branch GetBranch(int id, bool trackChanges)
        {
            return FindByCondition(x => x.branchId.Equals( id), trackChanges).Include(x => x.location).Include(c => c.brand).SingleOrDefault();
        }

        public IEnumerable<Branch> getByIds(IEnumerable<int> ids, bool trackChanges)
        {
            var branches = FindByCondition(x => ids.Contains(x.branchId), trackChanges).Include(x => x.location).Include(c => c.brand).ToList();
            return branches;
        }
    }
}
