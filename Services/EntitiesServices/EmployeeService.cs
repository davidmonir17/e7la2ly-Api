using Contracts.EntitiesRepository;
using Contracts;
using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects;
using Domain.ExceptionsClass;
using DataTransferObjects.CreationDto;
using Domain.Models;
using DataTransferObjects.UpdateDto;

namespace Services.EntitiesServices
{
    public class EmployeeService:IEmployeeService 
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDTO CreateEmployeeForbranch(int Branchid, EmployeeForCreationDto employee, bool trackChanges)
        {
            var Branch = _repository.Branch.GetBranch(Branchid, false);
            if (Branch == null)
            {
                throw new BranchNotFoundException(Branchid);
            }
            var emp=_mapper.Map<Employee>(employee);
            _repository.Employee.CreateEmployeeForBranch(Branchid, emp);
            _repository.save();
            var employeeDto=_mapper.Map<EmployeeDTO>(emp);
            return employeeDto;
        }

        public void DeleteEmployeeForBranch(int Branchid, int id, bool trackChanges)
        {
           var branch=_repository.Branch.GetBranch(Branchid, trackChanges);
            if (branch == null)
                throw new BranchNotFoundException(Branchid);
            var emp=_repository.Employee.GetEmployee(Branchid,id,trackChanges);
            if (emp == null)
                throw new EmployeeNotFoundException(id);
            _repository.Employee.DeleteEmployee(emp);
            _repository.save();
        }

        public IEnumerable<EmployeeDTO> getAllEmployees(int Branchid, bool trackChanges)
        {
            var branch = _repository.Branch.GetBranch(Branchid, false);
            if (branch == null)
            {
                throw new BranchNotFoundException(Branchid);
            }
            var employees=_repository.Employee.getAllEmployees(Branchid, trackChanges);
            var EmpDTO=_mapper.Map<IEnumerable< EmployeeDTO>>(employees);
            return EmpDTO;
        }

        public EmployeeDTO GetEmployee(int Branchid, int empid, bool trackchanges)
        {
            var branch=_repository.Branch.GetBranch(Branchid,false);
            if (branch == null)
            {
                throw new BranchNotFoundException(Branchid);
            }
            var employees = _repository.Employee.GetEmployee(Branchid,empid, trackchanges);
            if(employees == null)
            {
                throw new EmployeeNotFoundException(empid);
            }
            var EmpDTO = _mapper.Map<EmployeeDTO>(employees);
            return EmpDTO;
        }

        public void UpdateEmployeeForBranch(int Branchid, int id, EmployeeUpdateDTO employeeForUpdate, bool branTrackChanges, bool empTrackChanges)
        {
            var branch = _repository.Branch.GetBranch(Branchid, branTrackChanges);
            if (branch == null)
            {
                throw new BranchNotFoundException(Branchid);
            }
            var employees = _repository.Employee.GetEmployee(Branchid, id, empTrackChanges);
            if (employees == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            _mapper.Map(employeeForUpdate, employees);
            _repository.save();

        }
    }
}
