using MediatR;
using Test.Application.Commands.Base;

namespace Test.Application.Commands.Employee;

public record CreateEmployeeCommand(string FullName, string IdNumber, DateTime DateOfBirth, Guid CompanyId) : BaseCommand, IRequest<CreateEmployeeResponse>;