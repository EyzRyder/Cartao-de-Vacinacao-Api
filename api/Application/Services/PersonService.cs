using api.Application.DTOs;
using api.Domain.Entities;
using api.Domain.Interfaces;
using AutoMapper;

namespace api.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IVaccinationRecordRepository _vacinacaoRepository;
    private readonly IMapper _mapper;

    public PersonService(
        IPersonRepository personRepository,
        IVaccinationRecordRepository vacinacaoRepository,
        IMapper mapper)
    {
        _personRepository = personRepository;
        _vacinacaoRepository = vacinacaoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var persons = await _personRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PersonDto>>(persons);
    }

    public async Task<PersonDto?> GetByIdAsync(Guid id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        return _mapper.Map<PersonDto?>(person);
    }

    public async Task<Guid> CreateAsync(PersonCreateDto dto)
    {
        var entity = _mapper.Map<Person>(dto);
        await _personRepository.AddAsync(entity);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, PersonDto dto)
    {
        var existing = await _personRepository.GetByIdAsync(id);
        if (existing == null) return false;

        existing.Name = dto.Name;
        await _personRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return false;

        // Remove todas as vacinações da person
        var vacinacoes = await _vacinacaoRepository.GetByPersonIdAsync(id);
        foreach (var v in vacinacoes)
            await _vacinacaoRepository.DeleteAsync(v.Id);

        await _personRepository.DeleteAsync(id);
        return true;
    }
}
