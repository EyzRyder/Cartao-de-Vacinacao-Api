using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using api.Application.Profiles;

namespace api.Configurations;

public static class AutoMapperConfig
{
    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToDtoProfile), typeof(DtoToDomainProfile));
        return services;
    }
}
