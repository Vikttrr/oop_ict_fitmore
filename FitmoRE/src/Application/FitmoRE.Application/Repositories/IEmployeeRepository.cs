using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface IEmployeeRepository
{
    string Add(EmployeeModel employeeModel);

    EmployeeModel GetById(string id);

    EmployeeInfoResponseDto? Update(EmployeeModel employeeModel);

    EmployeeInfoDto? Delete(string employeeId);

    IEnumerable<EmployeeInfoResponseDto?> GetAll();
}