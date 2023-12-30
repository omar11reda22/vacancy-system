using paysky_task.Models;

namespace paysky_task.Services
{
    public interface IemployeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> getbyid(int id);

        Task<Employee> add(Employee model);
        Employee update(Employee model);
        Employee Delete(Employee model);
    }
}
