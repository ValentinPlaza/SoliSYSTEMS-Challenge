using MediatR;
using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;

namespace Test.Application.Queries.Employee.GetAll;

public class GetAllEmployeesQuery : IRequest<QueryPaginatedResponseDTO<EmployeesDTO>> { }