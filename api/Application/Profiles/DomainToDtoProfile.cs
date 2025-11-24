using AutoMapper;
using api.Domain.Entities;
using api.Application.DTOs;

namespace api.Application.Profiles;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<Vaccine, VaccineDto>();
        CreateMap<VaccinationRecord, VaccinationRecordDto>();
    }
}
