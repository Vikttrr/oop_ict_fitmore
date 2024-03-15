using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface IEmployeeRepository
{
    string Add(Employee employee);

    Employee GetById(string id);

    EmployeeInfoResponseDto? Update(Employee employee);

    EmployeeInfoDto? Delete(string employeeId);

    IEnumerable<EmployeeInfoResponseDto?> GetAll();
}