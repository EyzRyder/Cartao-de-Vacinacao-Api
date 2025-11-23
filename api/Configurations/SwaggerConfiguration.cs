using Microsoft.OpenApi.Models;

namespace api.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cartão de Vacinação API",
                Version = "v1",
                Description = "API para gerenciamento de vacinas, pessoas e registros de vacinação."
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cartão de Vacinação API v1");
            c.RoutePrefix = string.Empty; // Swagger na raiz (localhost:5125)
        });

        return app;
    }
}
