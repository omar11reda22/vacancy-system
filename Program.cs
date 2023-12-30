
using Microsoft.AspNetCore.Identity;
using paysky_task.Dataidentity;
using paysky_task.Models;
using paysky_task.MyContext;
using paysky_task.Services;

namespace paysky_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("defualtconnection");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<customcontext>().AddSignInManager();
          

            builder.Services.AddDbContext<customcontext>(option => option.UseSqlServer(connection));
            
            // registeration services
            builder.Services.AddScoped<IemployeService, employeeservice>();
            builder.Services.AddScoped<IVacancyService, VacancyService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}