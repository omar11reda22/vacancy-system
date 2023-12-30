
using paysky_task.Models;

namespace paysky_task.Services
{
    public class employeeservice : IemployeService
    {
        private readonly customcontext context;

        public employeeservice(customcontext context)
        {
            this.context = context;
        }

        public async Task<Employee> add(Employee model)
        {
           await context.employees.AddAsync(model);
            context.SaveChanges();
            return model;
        }

        public Employee Delete(Employee model)
        {
           
            context.Remove(model);
            context.SaveChanges();
            return model;
        }

        public async Task<List<Employee>>  GetAll()
        {
            return await context.employees.AsNoTracking().ToListAsync();
          
        }

        public async Task<Employee>  getbyid(int id)
        {
            return await context.employees.FirstOrDefaultAsync(s => s.ID == id);
        }

        public Employee update(Employee model)
        {
            context.employees.Update(model);
            context.SaveChanges();

            return model;
        }

       
    }
}
