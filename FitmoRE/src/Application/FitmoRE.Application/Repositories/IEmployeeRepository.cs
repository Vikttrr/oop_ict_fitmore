using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories
{
    public interface IEmployeeRepository
    {
        AddEmployeeResponseDto Add(Employee employeeDto);

        EmployeeInfoResponseDto GetById(string employeeInfoDto);

        EmployeeInfoResponseDto Update(AddEmployeeDto employeeDto);

        EmployeeInfoDto Delete(EmployeeInfoDto employeeInfoDto);

        IEnumerable<EmployeeInfoResponseDto> GetAll();
    }
}