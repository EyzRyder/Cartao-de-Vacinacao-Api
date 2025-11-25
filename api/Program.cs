
using api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContextConfiguration(builder.Configuration);

// Swagger
builder.Services.AddSwaggerConfiguration();

// DI / aka Services and Repos
builder.Services.AddDependencyInjectionConfiguration();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });


// AutoMapper
builder.Services.AddAutoMapperConfiguration();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Swagger pipeline

app.UseSwaggerConfiguration();


// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
