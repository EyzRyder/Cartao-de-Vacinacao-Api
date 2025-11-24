using api.Domain.Entities;

namespace api.Domain.Interfaces;

public interface IVaccinationRecordRepository
{
    Task<IEnumerable<VaccinationRecord>> GetAllAsync();
    Task<VaccinationRecord?> GetByIdAsync(Guid id);
    Task<IEnumerable<VaccinationRecord>> GetByPersonIdAsync(Guid personId);
    Task<IEnumerable<VaccinationRecord>> GetByVaccineIdAsync(Guid vacinaId);
    Task AddAsync(VaccinationRecord entity);
    Task UpdateAsync(VaccinationRecord entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
