// Data/InMemoryEmployeeRepository.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new()
    {
        new Employee { Id = 1, Name = "Aarav Verma", Department = "Engineering", Email = "aarav.verma@example.com", Salary = 850000 },
        new Employee { Id = 2, Name = "Meera Nair", Department = "HR", Email = "meera.nair@example.com", Salary = 620000 }
    };

    public Task<Employee?> GetAsync(int id) =>
        Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));

    public Task<IEnumerable<Employee>> GetAllAsync() =>
        Task.FromResult<IEnumerable<Employee>>(_employees);
}
