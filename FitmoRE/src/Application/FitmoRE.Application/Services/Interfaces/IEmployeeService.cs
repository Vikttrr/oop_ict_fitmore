using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Services.Interfaces;
public interface IEmployeeService
{
    AddEmployeeResponseDto AddEmployee(AddEmployeeDto employeeDto);

    EmployeeInfoResponseDto GetEmployeeInfo(string employeeId);
}