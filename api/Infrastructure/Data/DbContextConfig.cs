using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Configurations;

public static class DbContextConfig
{
    public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=VaccinationCard.db";

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        return services;
    }
}
