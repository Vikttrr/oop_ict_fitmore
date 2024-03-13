using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Application.Services.Interfaces;

namespace FitmoRE.Application.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public AddEmployeeResponseDto AddEmployee(AddEmployeeDto employeeDto)
    {
        var employee = new Employee(
            employeeDto.FullName,
            employeeDto.PhoneNumber,
            employeeDto.Email,
            DateTime.Parse(employeeDto.StartDate).ToString(),
            employeeDto.WorkSchedule,
            employeeDto.Position,
            true);

        string id = _employeeRepository.Add(employee);

        return new AddEmployeeResponseDto
        {
            EmployeeId = id,
        };
    }

    public EmployeeInfoResponseDto GetEmployeeInfo(string employeeId)
    {
        Employee employee = _employeeRepository.GetById(employeeId);
        if (employee == null)
        {
            // throw new InvalidOperationException("Employee is not found");
            return new EmployeeInfoResponseDto()
            {
                FullName = string.Empty,
            };
        }

        return new EmployeeInfoResponseDto
        {
            FullName = employee.FullName,
            PhoneNumber = employee.PhoneNumber,
            Email = employee.Email,
            StartDate = employee.StartDate,
            WorkSchedule = employee.WorkSchedule,
            Position = employee.Position,
        };
    }
}