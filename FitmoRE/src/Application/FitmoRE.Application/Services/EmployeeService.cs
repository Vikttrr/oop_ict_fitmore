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
        var id = new Random().Next().ToString();
        var employee = new Employee(
            id,
            employeeDto.FullName,
            employeeDto.PhoneNumber,
            employeeDto.Email,
            employeeDto.StartDate,
            employeeDto.WorkSchedule,
            employeeDto.Position,
            true);

        string newId = _employeeRepository.Add(employee);

        return new AddEmployeeResponseDto
        {
            EmployeeId = newId,
        };
    }

    public EmployeeInfoResponseDto GetEmployeeInfo(string employeeId)
    {
        Employee employee = _employeeRepository.GetById(employeeId);
        if (string.IsNullOrEmpty(employee.EmployeeId))
        {
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