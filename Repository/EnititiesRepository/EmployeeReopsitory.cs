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
    public class EmployeeReopsitory : RepositoryBase<Employee>, IEmployeeReopsitory
    {
        public EmployeeReopsitory(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public void CreateEmployeeForBranch(int Branchid, Employee employee)
        {
            employee.branchId = Branchid;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public IEnumerable<Employee> getAllEmployees(int Branchid, bool trackChanges)
        {
            return FindByCondition(x=>x.branchId==Branchid,trackChanges).Include(x=>x.location).OrderBy(c=>c.empid).ToList();
        }

        public Employee GetEmployee(int Branchid, int empid, bool trackchanges)
        {
            return FindByCondition(x => x.branchId == Branchid && x.empid == empid, trackchanges).Include(x => x.location).OrderBy(c => c.empid).SingleOrDefault();
        }
    }
}
