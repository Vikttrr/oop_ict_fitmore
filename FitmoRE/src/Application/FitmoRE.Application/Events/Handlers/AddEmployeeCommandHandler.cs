using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, AddEmployeeResponseDto>
{
    private readonly IEmployeeRepository _employeeRepository;

    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task<AddEmployeeResponseDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        string id = new Random().Next().ToString();
        var employee = new EmployeeModel(
            id,
            request.EmployeeDto.FullName,
            request.EmployeeDto.PhoneNumber,
            request.EmployeeDto.Email,
            request.EmployeeDto.StartDate,
            request.EmployeeDto.WorkSchedule,
            request.EmployeeDto.Position,
            true);

        string newId = _employeeRepository.Add(employee);

        var responseDto = new AddEmployeeResponseDto
        {
            EmployeeId = newId,
        };

        return Task.FromResult(responseDto);
    }
}