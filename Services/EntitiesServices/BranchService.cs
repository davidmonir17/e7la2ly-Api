using AutoMapper;
using Contracts;
using Contracts.EntitiesRepository;
using Contracts.Services;
using DataTransferObjects;
using DataTransferObjects.CreationDto;
using Domain.ExceptionsClass;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntitiesServices
{
    public class BranchService:IBranchService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public BranchService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public BranchDTO AddBranch(BranchCreationDto branch)
        {

            var barnchEntity = _mapper.Map<Branch>(branch);
            _repository.Branch.AddBranch(barnchEntity);
            _repository.save();
            var bran = _mapper.Map<BranchDTO>(barnchEntity);
            return bran;
        }

        public BranchDTO AddBranchWithEmp(BranchWithEmpDto branch)
        {
            var bran = _mapper.Map<Branch>(branch.branch);
            bran.employees = _mapper.Map<ICollection< Employee>>(branch.emps);
            _repository.Branch.AddBranch(bran);
            _repository.save();
            var branchs = _repository.Branch.GetBranch(bran.branchId, false);
            var branc = _mapper.Map<BranchDTO>(branchs);
            return branc;
          
        }

        public (IEnumerable<BranchDTO> companies, string ids) CreateCompanyCollection(IEnumerable<BranchCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();
            var branch = _mapper.Map<IEnumerable<Branch>>(companyCollection);
            foreach(var entity in branch)
            {
                _repository.Branch.AddBranch(entity);
            }
            _repository.save();
            var branchesDto=_mapper.Map<IEnumerable<BranchDTO>>(branch);
            var ids = string.Join(",", branchesDto.Select(c => c.branchId));
            return (companies: branchesDto, ids: ids);

        }

        public void DeleteBranch(int id, bool trackChanges)
        {
            var branch = _repository.Branch.GetBranch(id, trackChanges);
            if (branch == null)
                throw new BranchNotFoundException(id);
            _repository.Branch.DeleteBranch(branch);
            _repository.save();

        }

        public IEnumerable<BranchDTO> GetAlBrancheCollection(IEnumerable<int> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var brach=_repository.Branch.getByIds(ids, trackChanges);
            if (ids.Count() != brach.Count())
                throw new CollectionByIdsBadRequestException();

            var branche = _mapper.Map<IEnumerable<BranchDTO>>(brach);
            return branche;
        }

        public IEnumerable<BranchDTO> GetAlBranchess(bool trackChanges)
        {
            var branches=_repository.Branch.GetAllBranches(trackChanges);
            var branchesDto=_mapper.Map<IEnumerable< BranchDTO>>(branches);
            return branchesDto;
        }

        public BranchDTO GetBranch(int id, bool trackChanges)
        {
           var branch= _repository.Branch.GetBranch(id,trackChanges);
            if (branch == null)
            {
                throw new BranchNotFoundException(id);
            }
            var branchDto= _mapper.Map<BranchDTO>(branch);
            return branchDto;
        }
    }
}
