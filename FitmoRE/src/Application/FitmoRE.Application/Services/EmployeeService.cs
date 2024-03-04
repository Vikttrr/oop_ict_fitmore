namespace FitmoRE.Application.Services
{
    using FitmoRE.Application.DTO;
    using FitmoRE.Application.Models.Entities;
    using FitmoRE.Application.Models.Entities.Repositories;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployee(EmployeeDto dto)
        {
            var employee = new Employee(
                0,
                dto.FullName,
                dto.PhoneNumber,
                dto.Email,
                dto.StartDate,
                dto.WorkSchedule,
                dto.Position,
                dto.IsActive);

            _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();

            return employee;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found with ID " + employeeId);
            }

            return employee;
        }
    }
}