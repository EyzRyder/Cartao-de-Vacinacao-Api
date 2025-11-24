using api.Application.Services;
using api.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;


using api.Domain.Interfaces;
using api.Infrastructure.Repositories;

namespace api.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        // Validators
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(PersonCreateValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(VaccineCreateValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(VaccinationRecordCreateValidator).Assembly);

        // Repositories
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IVaccineRepository, VaccineRepository>();
        services.AddScoped<IVaccinationRecordRepository, VaccinationRecordRepository>();

        // Services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IVaccineService, VaccineService>();
        services.AddScoped<IVaccinationRecordService, VaccinationRecordService>();

        return services;
    }
}
