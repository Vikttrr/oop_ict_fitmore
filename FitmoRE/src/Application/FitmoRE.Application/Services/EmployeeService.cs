using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
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
        string id = new Random().Next().ToString();
        var employee = new EmployeeModel(
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
        EmployeeModel employeeModel = _employeeRepository.GetById(employeeId);
        if (string.IsNullOrEmpty(employeeModel.EmployeeId))
        {
            return new EmployeeInfoResponseDto()
            {
                FullName = string.Empty,
            };
        }

        return new EmployeeInfoResponseDto
        {
            FullName = employeeModel.FullName,
            PhoneNumber = employeeModel.PhoneNumber,
            Email = employeeModel.Email,
            StartDate = employeeModel.StartDate,
            WorkSchedule = employeeModel.WorkSchedule,
            Position = employeeModel.Position,
        };
    }
}