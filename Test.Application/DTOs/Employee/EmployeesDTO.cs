using System.Collections.ObjectModel;
using Test.Application.Queries.Base;

namespace Test.Application.DTOs.Employee;

public class EmployeesDTO: Collection<EmployeeDTO>, IQueryDataResponse
{
    public EmployeesDTO(IList<EmployeeDTO> employees) : base(employees){}
}
