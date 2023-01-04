using DataTransferObjects;
using DataTransferObjects.CreationDto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IBranchService
    {
        IEnumerable<BranchDTO> GetAlBranchess(bool trackChanges);
        BranchDTO GetBranch(int id, bool trackChanges);
        BranchDTO AddBranch(BranchCreationDto branch);
        BranchDTO AddBranchWithEmp(BranchWithEmpDto branch);
        IEnumerable<BranchDTO> GetAlBrancheCollection(IEnumerable<int> ids, bool trackChanges);
        (IEnumerable<BranchDTO> companies, string ids) CreateCompanyCollection(IEnumerable<BranchCreationDto> companyCollection);
        void DeleteBranch(int id, bool trackChanges);


    }
}
