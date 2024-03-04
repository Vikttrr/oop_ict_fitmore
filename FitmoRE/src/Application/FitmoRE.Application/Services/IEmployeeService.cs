namespace FitmoRE.Application.Services
{
    using FitmoRE.Application.DTO;
    using FitmoRE.Application.Models.Entities;

    public interface IEmployeeService
    {
        Employee AddEmployee(EmployeeDto dto);

        Employee GetEmployeeById(int employeeId);
    }
}