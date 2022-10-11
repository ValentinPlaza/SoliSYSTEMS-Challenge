using MediatR;
using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;

namespace Test.Application.Queries.Employee.GetAll;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, QueryPaginatedResponseDTO<EmployeesDTO>>
{
    private readonly IEmployeeQueries _employeeQueries;

    public GetAllEmployeesHandler(IEmployeeQueries employeeQueries)
    {
        _employeeQueries = employeeQueries;
    }

    public async Task<QueryPaginatedResponseDTO<EmployeesDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _employeeQueries.ListEmployeesAsync(cancellationToken);
    }
}
