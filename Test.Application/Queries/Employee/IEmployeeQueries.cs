using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;

namespace Test.Application.Queries.Employee;

public interface IEmployeeQueries : IQueriesCollection
{
    public Task<QueryPaginatedResponseDTO<EmployeesDTO>> ListEmployeesAsync(
        CancellationToken cancellationToken = default(CancellationToken));
}