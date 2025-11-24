using api.Application.DTOs;
using api.Domain.Entities;
using api.Domain.Enums;
using api.Domain.Interfaces;
using AutoMapper;

namespace api.Application.Services;

public class VaccinationRecordService : IVaccinationRecordService
{
    private readonly IVaccinationRecordRepository _vaccinationRecordRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IVaccineRepository _vaccineRepository;
    private readonly IMapper _mapper;

    public VaccinationRecordService(
        IVaccinationRecordRepository vaccinationRecordRepository,
        IPersonRepository personRepository,
        IVaccineRepository vaccineRepository,
        IMapper mapper)
    {
        _vaccinationRecordRepository = vaccinationRecordRepository;
        _personRepository = personRepository;
        _vaccineRepository = vaccineRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VaccinationRecordDto>> GetAllAsync()
    {
        var vaccinecoes = await _vaccinationRecordRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VaccinationRecordDto>>(vaccinecoes);
    }

    public async Task<IEnumerable<VaccinationRecordDto>> GetByPersonIdAsync(Guid personId)
    {
        var vaccinecoes = await _vaccinationRecordRepository.GetByPersonIdAsync(personId);
        return _mapper.Map<IEnumerable<VaccinationRecordDto>>(vaccinecoes);
    }

    public async Task<VaccinationRecordDto?> GetByIdAsync(Guid id)
    {
        var vac = await _vaccinationRecordRepository.GetByIdAsync(id);
        return _mapper.Map<VaccinationRecordDto?>(vac);
    }

    public async Task<Guid> CreateAsync(VaccinationRecordCreateDto dto)
    {
        var person = await _personRepository.GetByIdAsync(dto.PersonId);
        if (person == null)
            throw new Exception("Person não encontrada");

        var vaccine = await _vaccineRepository.GetByIdAsync(dto.VaccineId);
        if (vaccine == null)
            throw new Exception("Vaccine não encontrada");

        if (!Enum.IsDefined(typeof(Dose), dto.Dose))
            throw new Exception("Dose inválida");

        var entity = _mapper.Map<VaccinationRecord>(dto);
        entity.DateAplication = DateTime.UtcNow;

        await _vaccinationRecordRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var vac = await _vaccinationRecordRepository.GetByIdAsync(id);
        if (vac == null) return false;

        await _vaccinationRecordRepository.DeleteAsync(id);
        return true;
    }
}
