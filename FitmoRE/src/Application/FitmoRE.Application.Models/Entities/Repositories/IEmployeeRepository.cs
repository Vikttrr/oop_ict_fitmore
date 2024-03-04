namespace FitmoRE.Application.Models.Entities.Repositories;

public interface IEmployeeRepository
{
    void Add(Employee employee);

    Employee GetById(int employeeId);

    void SaveChanges();
}