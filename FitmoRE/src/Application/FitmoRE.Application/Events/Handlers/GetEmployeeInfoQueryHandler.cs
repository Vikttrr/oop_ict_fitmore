using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Queries;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class GetEmployeeInfoQueryHandler : IRequestHandler<GetEmployeeInfoQuery, EmployeeInfoResponseDto>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeInfoQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task<EmployeeInfoResponseDto> Handle(GetEmployeeInfoQuery request, CancellationToken cancellationToken)
    {
        EmployeeModel employeeModel = _employeeRepository.GetById(request.EmployeeId);
        if (employeeModel == null || string.IsNullOrEmpty(employeeModel.EmployeeId))
        {
            return Task.FromResult(new EmployeeInfoResponseDto
            {
                FullName = string.Empty,
            });
        }

        var responseDto = new EmployeeInfoResponseDto
        {
            FullName = employeeModel.FullName,
            PhoneNumber = employeeModel.PhoneNumber,
            Email = employeeModel.Email,
            StartDate = employeeModel.StartDate,
            WorkSchedule = employeeModel.WorkSchedule,
            Position = employeeModel.Position,
        };

        return Task.FromResult(responseDto);
    }
}