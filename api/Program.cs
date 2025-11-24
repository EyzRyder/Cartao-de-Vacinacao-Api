
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
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


// AutoMapper
builder.Services.AddAutoMapperConfiguration();

var app = builder.Build();

// Swagger pipeline

// if (app.Environment.IsDevelopment())
// {
app.UseSwaggerConfiguration();

// }
// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

