using paysky_task.DTOs;
using paysky_task.Models;

namespace paysky_task.Services
{
    public interface IVacancyService
    {
        Task<Vacancy> Create(Vacancy model);
        Vacancy? update(EditingDTO model);
        Task<Vacancy> getbyid(int id);

        Vacancy Delete(Vacancy model);

        Vacancy DeactivateVacancy(Vacancy model);


    }
}
