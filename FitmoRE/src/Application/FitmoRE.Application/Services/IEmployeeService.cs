using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Models.Entities.Repositories;

namespace FitmoRE.Application.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(AddEmployeeDto employeeDto);

        EmployeeInfoResponseDto GetEmployeeInfo(int employeeId);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(AddEmployeeDto employeeDto)
        {
            var employee = new Employee(
                employeeDto.EmployeeId,
                employeeDto.FullName,
                employeeDto.PhoneNumber,
                employeeDto.Email,
                employeeDto.StartDate,
                employeeDto.WorkSchedule,
                employeeDto.Position,
                true);
            _employeeRepository.Add(employee);
        }

        public EmployeeInfoResponseDto GetEmployeeInfo(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee is not found");
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
}