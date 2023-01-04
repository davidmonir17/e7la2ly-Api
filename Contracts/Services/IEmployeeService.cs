using DataTransferObjects;
using DataTransferObjects.CreationDto;
using DataTransferObjects.UpdateDto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> getAllEmployees(int Branchid, bool trackChanges);
        EmployeeDTO GetEmployee(int Branchid, int empid, bool trackchanges);
        EmployeeDTO CreateEmployeeForbranch(int Branchid, EmployeeForCreationDto employee,bool trackChanges);
        void DeleteEmployeeForBranch(int Branchid, int id, bool trackChanges);
        void UpdateEmployeeForBranch(int Branchid, int id, EmployeeUpdateDTO employeeForUpdate, bool branTrackChanges, bool empTrackChanges);

    }
}
