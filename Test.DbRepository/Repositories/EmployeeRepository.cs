using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DbRepository.Repositories.Base;
using Test.Domain.Entities;
using Test.Repository;

namespace Test.DbRepository.Repositories;

public class EmployeeRepository: EntityFrameworkRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> EmployeeExistsAsync(string employeeIdNumber)
    {
        return await DbContext.Set<Employee>().AnyAsync(e => e.IdNumber == employeeIdNumber);
    }
}