using Dapper;
using Microsoft.Extensions.Logging;
using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;

namespace Test.Application.Queries.Employee;

public class EmployeeQueries : QueryRunner, IEmployeeQueries
{
    public EmployeeQueries(QueryConnectionString connectionString, ILogger<EmployeeQueries> logger) :
        base(connectionString, logger)
    { }

    private EmployeeDTO MapToEmployeeDTO(dynamic row)
    {
        return new EmployeeDTO()
        {
            Id = row.id,
            FullName = row.full_name,
            IdNumber = row.id_number,
            DateOfBirth = row.date_of_birth,
            CompanyId = row.company_id,
            CreatedAt = row.created_at
        };
    }

    public async Task<QueryPaginatedResponseDTO<EmployeesDTO>> ListEmployeesAsync(
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var employees = await RunQueryAsync(
            @"SELECT id, full_name, id_number, date_of_birth, company_id, created_at
                     FROM employee", cancellationToken);

        return new QueryPaginatedResponseDTO<EmployeesDTO>(
            new EmployeesDTO(employees.AsList().Select<dynamic, EmployeeDTO>(c => MapToEmployeeDTO(c))
                .ToList<EmployeeDTO>()),
            10, 1, 1);
    }
}
