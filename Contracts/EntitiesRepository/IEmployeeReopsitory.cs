using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.EntitiesRepository
{
    public interface IEmployeeReopsitory
    {
        IEnumerable<Employee> getAllEmployees(int Branchid,bool trackChanges);
        Employee GetEmployee(int Branchid,int empid,bool trackchanges);
        void CreateEmployeeForBranch(int Branchid, Employee employee);
        void DeleteEmployee(Employee employee);


    }
}
