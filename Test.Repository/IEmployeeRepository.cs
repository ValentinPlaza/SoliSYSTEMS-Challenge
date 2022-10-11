using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Repository;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<bool> EmployeeExistsAsync(string employeeIdNumber);
}
