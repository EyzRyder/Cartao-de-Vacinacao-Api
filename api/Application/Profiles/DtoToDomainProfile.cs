using AutoMapper;
using api.Domain.Entities;
using api.Application.DTOs;

namespace api.Application.Profiles;

public class DtoToDomainProfile : Profile
{
    public DtoToDomainProfile()
    {
        CreateMap<PersonDto, Person>();
        CreateMap<PersonCreateDto, Person>();
        CreateMap<VaccineDto, Vaccine>();
        CreateMap<VaccineCreateDto, Vaccine>();
        CreateMap<VaccinationRecordDto, VaccinationRecord>();
        CreateMap<VaccinationRecordCreateDto, VaccinationRecord>();
    }
}
