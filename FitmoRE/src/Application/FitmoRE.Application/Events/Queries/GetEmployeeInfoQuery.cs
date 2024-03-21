using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Queries
{
    public class GetEmployeeInfoQuery : IRequest<EmployeeInfoResponseDto>
    {
        public string EmployeeId { get; }

        public GetEmployeeInfoQuery(string employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}