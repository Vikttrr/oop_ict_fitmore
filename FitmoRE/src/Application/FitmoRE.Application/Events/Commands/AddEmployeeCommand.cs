using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Commands
{
    public class AddEmployeeCommand : IRequest<AddEmployeeResponseDto>
    {
        public AddEmployeeDto EmployeeDto { get; }

        public AddEmployeeCommand(AddEmployeeDto employeeDto)
        {
            EmployeeDto = employeeDto;
        }
    }
}