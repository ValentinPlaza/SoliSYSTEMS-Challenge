using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.API.DTOs.Errors;
using Test.Application.Commands.Employee;
using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;
using Test.Application.Queries.Employee.GetAll;

namespace Test.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)//, IEmployeeQueries employeeQueries)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResponseDTO), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<CreateEmployeeResponse>> Create([FromBody] CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send<CreateEmployeeResponse>(request, cancellationToken));
    }
    [HttpGet()]
    [ProducesResponseType(typeof(PaginatedDataResponse<EmployeesDTO>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundDTO), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<QueryPaginatedResponseDTO<EmployeesDTO>>> List(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllEmployeesQuery()));
    }
}
