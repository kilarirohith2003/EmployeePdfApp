// Data/IEmployeeRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmployeeRepository
{
    Task<Employee?> GetAsync(int id);
    Task<IEnumerable<Employee>> GetAllAsync();
}
