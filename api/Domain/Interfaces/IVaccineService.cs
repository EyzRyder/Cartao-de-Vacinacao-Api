using api.Application.DTOs;

namespace api.Domain.Interfaces;

public interface IVaccineService
{
    Task<IEnumerable<VaccineDto>> GetAllAsync();
    Task<VaccineDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(VaccineCreateDto dto);
    Task<bool> UpdateAsync(Guid id, VaccineDto dto);
    Task<bool> DeleteAsync(Guid id);
}
