using Contracts.EntitiesRepository;
using Domain.DatabaseContext;
using Repository.EnititiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        //Lazy class to ensure the lazy
        //initialization of our repositories.This means that our repository instances
        //are only going to be created when we access them for the first time, and
        //not before that.
        private readonly DataBaseContext _dbContext;
        private readonly Lazy<IBranchRepository>     _branchRepository;
        private readonly Lazy<IBrandRepository>      _brandRepository;
        private readonly Lazy<IClientRepository>     _clientRepository;
        private readonly Lazy<IEmployeeReopsitory>   _employeeReopsitory;
        private readonly Lazy<IEmpShiftRepository>   _empShiftRepository;
        private readonly Lazy<IEmpWorkingRepository> _empWorkingRepository;
        private readonly Lazy<ILocationReposetory>   _locationReposetory;
        private readonly Lazy<IShiftRepository>      _shiftRepository;
        

        public RepositoryManager(DataBaseContext repositoryContext)
        {
            _dbContext = repositoryContext;
            _branchRepository = new Lazy<IBranchRepository>(() => new BranchRepository(repositoryContext));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(repositoryContext));
            _clientRepository = new Lazy<IClientRepository>(() => new ClientRepository(repositoryContext));
            _employeeReopsitory = new Lazy<IEmployeeReopsitory>(() => new EmployeeReopsitory(repositoryContext));
            _empShiftRepository = new Lazy<IEmpShiftRepository>(() => new EmpShiftRepository(repositoryContext));
            _empWorkingRepository = new Lazy<IEmpWorkingRepository>(() => new EmpWorkingRepository(repositoryContext));
            _locationReposetory = new Lazy<ILocationReposetory>(() => new LocationReposetory(repositoryContext));
            _shiftRepository = new Lazy<IShiftRepository>(() => new ShiftRepository(repositoryContext));
            
        }

        public IBranchRepository Branch => _branchRepository.Value;

        public IBrandRepository Brand => _brandRepository.Value;

        public IClientRepository Client => _clientRepository.Value;

        public IEmployeeReopsitory Employee => _employeeReopsitory.Value;

        public IEmpShiftRepository EmpShift => _empShiftRepository.Value;

        public IEmpWorkingRepository EmpWorking => _empWorkingRepository.Value;

        public ILocationReposetory Location => _locationReposetory.Value;

        public IShiftRepository Shift => _shiftRepository.Value;

        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
