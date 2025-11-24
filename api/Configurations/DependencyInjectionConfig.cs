using api.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;


namespace api.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(PersonCreateValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(VaccineCreateValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(VaccinationRecordCreateValidator).Assembly);

        return services;
    }
}
