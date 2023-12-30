using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using paysky_task.DTOs;
using paysky_task.Models;

namespace paysky_task.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly customcontext context;

        public VacancyService(customcontext context)
        {
            this.context = context;
        }

        public async Task<Vacancy> Create(Vacancy model)
        {
           await context.vacancies.AddAsync(model);
            return model;
        }

        public Vacancy DeactivateVacancy(Vacancy model)
        {
            var vacancy = context.vacancies.FirstOrDefault(s => s.Id == model.Id);
            vacancy.IsActive = false;
            context.SaveChanges();
            return vacancy;
        }

        public Vacancy Delete(Vacancy model)
        {
            context.Remove(model);
            context.SaveChanges();
            return model;
        }

        //public  List<Applicant> GetAll(int id)
        //{
        //    var vacancy = context.vacancies
        //    .Include(v => v.applicants)
        //    .FirstOrDefault(v => v.Id == id);


        //    var applicants =  vacancy.applicants.Select(s => new Applicant { Id = s.Id,Name = s.Name } ).ToList();
        //    return applicants;

        //}

        public async Task<Vacancy> getbyid(int id)
        {
            return await context.vacancies.FirstOrDefaultAsync(s => s.Id == id);
             
        }

        public Vacancy update( EditingDTO model)
        {
            var item = context.vacancies.FirstOrDefault(s => s.Id == model.Id);
            if (item == null)
                return null;

            item.Description = model.Description;
            item.ExpireDae = model.ExpireDae;
            item.Title = model.Title;
            item.MaxApplications = model.MaxApplications;

            context.Update(item);
            context.SaveChanges();

            return item;
        }

       
    }
}
