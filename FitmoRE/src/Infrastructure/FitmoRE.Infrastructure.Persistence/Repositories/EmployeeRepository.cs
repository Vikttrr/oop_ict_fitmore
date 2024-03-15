using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(Employee employee)
        {
            FitmoRE.Infrastructure.Persistence.Entities.Employee entity = MapEmployeeToEntity(employee);
            _dbContext.Employees?.Add(entity);
            _dbContext.SaveChanges();
            return entity.EmployeeId;
        }

        public Employee GetById(string id)
        {
            FitmoRE.Infrastructure.Persistence.Entities.Employee? entity =
                _dbContext.Employees?.FirstOrDefault(c => c.EmployeeId == id);
            return (entity != null ? MapEntityToEmployee(entity) : null) ?? new Employee();
        }

        public EmployeeInfoResponseDto? Update(Employee employee)
        {
            FitmoRE.Infrastructure.Persistence.Entities.Employee? existingEntity = _dbContext.Employees?.FirstOrDefault(c => c.EmployeeId == employee.EmployeeId);
            if (existingEntity != null)
            {
                existingEntity.Fullname = employee.FullName;
                existingEntity.Phonenumber = employee.PhoneNumber;
                existingEntity.Email = employee.Email;
                existingEntity.Startdate = employee.StartDate;
                existingEntity.Workschedule = employee.WorkSchedule;
                existingEntity.Position = employee.Position;
                existingEntity.Isactive = employee.IsActive;

                _dbContext.SaveChanges();

                return MapEntityToEmployeeInfoResponseDto(existingEntity);
            }

            return null;
        }

        public EmployeeInfoDto? Delete(string employeeId)
        {
            FitmoRE.Infrastructure.Persistence.Entities.Employee? entity = _dbContext.Employees?.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (entity != null)
            {
                _dbContext.Employees?.Remove(entity);
                _dbContext.SaveChanges();
                return MapEntityToEmployeeInfoDto(entity);
            }

            return null;
        }

        public IEnumerable<EmployeeInfoResponseDto?> GetAll()
        {
            var employeeEntities = _dbContext.Employees?.ToList();
            return employeeEntities?.Select(MapEntityToEmployeeInfoResponseDto) ?? Array.Empty<EmployeeInfoResponseDto>();
        }

        private Employee MapEntityToEmployee(FitmoRE.Infrastructure.Persistence.Entities.Employee entity)
        {
            return new Employee
            {
                EmployeeId = entity.EmployeeId,
                FullName = entity.Fullname,
                PhoneNumber = entity.Phonenumber,
                Email = entity.Email,
                StartDate = entity.Startdate,
                WorkSchedule = entity.Workschedule,
                Position = entity.Position,
                IsActive = entity.Isactive,
            };
        }

        private FitmoRE.Infrastructure.Persistence.Entities.Employee MapEmployeeToEntity(Employee model)
        {
            return new FitmoRE.Infrastructure.Persistence.Entities.Employee
            {
                // EmployeeId = model.EmployeeId,
                Fullname = model.FullName,
                Phonenumber = model.PhoneNumber,
                Email = model.Email,
                Startdate = model.StartDate,
                Workschedule = model.WorkSchedule,
                Position = model.Position,
                Isactive = model.IsActive,
            };
        }

        private EmployeeInfoResponseDto MapEntityToEmployeeInfoResponseDto(FitmoRE.Infrastructure.Persistence.Entities.Employee entity)
        {
            return new EmployeeInfoResponseDto
            {
                FullName = entity.Fullname,
                PhoneNumber = entity.Phonenumber,
                Email = entity.Email,
                StartDate = entity.Startdate,
                WorkSchedule = entity.Workschedule,
                Position = entity.Position,
            };
        }

        private EmployeeInfoDto MapEntityToEmployeeInfoDto(FitmoRE.Infrastructure.Persistence.Entities.Employee entity)
        {
            return new EmployeeInfoDto
            {
                EmployeeId = entity.EmployeeId,
            };
        }
    }