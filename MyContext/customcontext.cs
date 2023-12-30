
using paysky_task.Dataidentity;
using paysky_task.Models;

namespace paysky_task.MyContext
{
    public class customcontext:IdentityDbContext<Applicationuser>
    {
        public customcontext()
        {
            
        }
        public customcontext(DbContextOptions<customcontext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=paysky-task;Integrated Security=True;TrustServerCertificate=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Employee> employees { get; set; }
        public DbSet<Vacancy> vacancies { get; set; }
        public DbSet<Applicant> applicants { get; set; }
    }
}
