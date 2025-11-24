using api.Application.DTOs;

namespace api.Domain.Interfaces;

public interface IVaccinationRecordService
{
    Task<IEnumerable<VaccinationRecordDto>> GetAllAsync();
    Task<IEnumerable<VaccinationRecordDto>> GetByPersonIdAsync(Guid personId);
    Task<VaccinationRecordDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(VaccinationRecordDto dto);
    Task<bool> DeleteAsync(Guid id);
}
