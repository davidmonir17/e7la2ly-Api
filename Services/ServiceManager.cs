using AutoMapper;
using Contracts;
using Contracts.EntitiesRepository;
using Contracts.Services;
using Domain.DatabaseContext;
using Services.EntitiesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        
        private readonly Lazy<IBranchService> _branchService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IClientService> _clientService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IEmpShiftService> _empShiftService;
        private readonly Lazy<IEmpWorkingService> _empWorkingService;
        private readonly Lazy<ILocationService> _locationService;
        private readonly Lazy<IShiftService> _shiftService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _branchService = new Lazy<IBranchService>(() => new BranchService(repository, logger, mapper));
            _brandService = new Lazy<IBrandService>(() => new BrandService(repository, logger, mapper));
            _clientService = new Lazy<IClientService>(() => new ClientServices(repository, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, logger, mapper));
            _empShiftService = new Lazy<IEmpShiftService>(() => new EmpShiftService(repository, logger, mapper));
            _empWorkingService = new Lazy<IEmpWorkingService>(() => new EmpWorkingService(repository, logger, mapper));
            _locationService = new Lazy<ILocationService>(() => new LocationService(repository, logger, mapper));
            _shiftService = new Lazy<IShiftService>(() => new ShiftService(repository, logger,mapper));
            //_branchService = new Lazy<IBranchService>(() => new BranchService(repository, logger));
        }

        public IBranchService Branch => _branchService.Value;

        public IBrandService Brand => _brandService.Value;

        public IClientService Client => _clientService.Value;

        public IEmployeeService Employee => _employeeService.Value;

        public IEmpShiftService EmpShift => _empShiftService.Value;

        public IEmpWorkingService EmpWorking => _empWorkingService.Value;

        public ILocationService Location => _locationService.Value;

        public IShiftService Shift => _shiftService.Value;
    }
}
