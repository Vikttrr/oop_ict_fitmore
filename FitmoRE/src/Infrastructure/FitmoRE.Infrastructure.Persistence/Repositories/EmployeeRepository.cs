using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Entities;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(EmployeeModel employeeModel)
        {
            Employee entity = MapEmployeeToEntity(employeeModel);
            _dbContext.Employees?.Add(entity);
            _dbContext.SaveChanges();
            return entity.EmployeeId;
        }

        public EmployeeModel GetById(string id)
        {
            Employee? entity =
                _dbContext.Employees?.FirstOrDefault(c => c.EmployeeId == id);
            return (entity != null ? MapEntityToEmployee(entity) : null) ?? new EmployeeModel();
        }

        public EmployeeInfoResponseDto? Update(EmployeeModel employeeModel)
        {
            Employee? existingEntity = _dbContext.Employees?.FirstOrDefault(c => c.EmployeeId == employeeModel.EmployeeId);
            if (existingEntity != null)
            {
                existingEntity.Fullname = employeeModel.FullName;
                existingEntity.Phonenumber = employeeModel.PhoneNumber;
                existingEntity.Email = employeeModel.Email;
                existingEntity.Startdate = employeeModel.StartDate;
                existingEntity.Workschedule = employeeModel.WorkSchedule;
                existingEntity.Position = employeeModel.Position;
                existingEntity.Isactive = employeeModel.IsActive;

                _dbContext.SaveChanges();

                return MapEntityToEmployeeInfoResponseDto(existingEntity);
            }

            return null;
        }

        public EmployeeInfoDto? Delete(string employeeId)
        {
            Employee? entity = _dbContext.Employees?.FirstOrDefault(e => e.EmployeeId == employeeId);
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

        private EmployeeModel MapEntityToEmployee(Employee entity)
        {
            return new EmployeeModel
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

        private Employee MapEmployeeToEntity(EmployeeModel model)
        {
            return new Employee
            {
                EmployeeId = model.EmployeeId,
                Fullname = model.FullName,
                Phonenumber = model.PhoneNumber,
                Email = model.Email,
                Startdate = model.StartDate,
                Workschedule = model.WorkSchedule,
                Position = model.Position,
                Isactive = model.IsActive,
            };
        }

        private EmployeeInfoResponseDto MapEntityToEmployeeInfoResponseDto(Employee entity)
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

        private EmployeeInfoDto MapEntityToEmployeeInfoDto(Employee entity)
        {
            return new EmployeeInfoDto
            {
                EmployeeId = entity.EmployeeId,
            };
        }
    }