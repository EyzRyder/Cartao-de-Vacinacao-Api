using api.Domain.Entities;

namespace api.Domain.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(Guid id);
    Task AddAsync(Person entity);
    Task UpdateAsync(Person entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
