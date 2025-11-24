using api.Application.DTOs;
using api.Domain.Entities;
using api.Domain.Interfaces;
using AutoMapper;

namespace api.Application.Services;

public class VaccineService : IVaccineService
{
    private readonly IVaccineRepository _vaccineRepository;
    private readonly IMapper _mapper;

    public VaccineService(IVaccineRepository vaccineRepository, IMapper mapper)
    {
        _vaccineRepository = vaccineRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VaccineDto>> GetAllAsync()
    {
        var vaccines = await _vaccineRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VaccineDto>>(vaccines);
    }

    public async Task<VaccineDto?> GetByIdAsync(Guid id)
    {
        var vaccine = await _vaccineRepository.GetByIdAsync(id);
        return _mapper.Map<VaccineDto?>(vaccine);
    }

    public async Task<Guid> CreateAsync(VaccineCreateDto dto)
    {
        var entity = _mapper.Map<Vaccine>(dto);
        await _vaccineRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, VaccineDto dto)
    {
        var existing = await _vaccineRepository.GetByIdAsync(id);
        if (existing == null) return false;

        existing.Name = dto.Name;

        await _vaccineRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var vaccine = await _vaccineRepository.GetByIdAsync(id);
        if (vaccine == null)
            return false;

        await _vaccineRepository.DeleteAsync(id);
        return true;
    }
}
