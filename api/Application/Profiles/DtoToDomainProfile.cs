using AutoMapper;
using api.Domain.Entities;
using api.Application.DTOs;

namespace api.Application.Profiles;

public class DtoToDomainProfile : Profile
{
    public DtoToDomainProfile()
    {
        CreateMap<PersonDto, Person>();
        CreateMap<VaccineDto, Vaccine>();
        CreateMap<VaccinationRecordDto, VaccinationRecord>();
    }
}
