using api.Domain.Entities;

namespace api.Domain.Interfaces;

public interface IVaccineRepository
{
    Task<IEnumerable<Vaccine>> GetAllAsync();
    Task<Vaccine?> GetByIdAsync(Guid id);
    Task AddAsync(Vaccine entity);
    Task UpdateAsync(Vaccine entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
