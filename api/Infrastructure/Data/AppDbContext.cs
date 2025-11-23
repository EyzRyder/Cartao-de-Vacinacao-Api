using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<VaccinationRecord> VaccinationRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Automatically applies all mappings from the Mappings 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
