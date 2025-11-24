using api.Application.DTOs;

namespace api.Domain.Interfaces;

public interface IPersonService 
{
    Task<IEnumerable<PersonDto>> GetAllAsync();
    Task<PersonDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(PersonDto dto);
    Task<bool> UpdateAsync(Guid id, PersonDto dto);
    Task<bool> DeleteAsync(Guid id);
}
