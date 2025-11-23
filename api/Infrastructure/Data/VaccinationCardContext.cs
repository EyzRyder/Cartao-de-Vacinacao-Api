using api.Domain.Entities;
using api.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Data;

public class VaccinationCardContext : DbContext
{
    public VaccinationCardContext(DbContextOptions<VaccinationCardContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; } = default!;
    public DbSet<Vaccine> Vaccines { get; set; } = default!;
    public DbSet<VaccinationRecord> Vaccinecoes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Person -> VaccinationRecords (1:N) One to many with cascade delete
        modelBuilder.Entity<Person>()
            .HasMany(p => p.VaccinationRecords)
            .WithOne(v => v.Person)
            .HasForeignKey(v => v.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Vaccine -> VaccinationRecords (1:N) One to many with delete restrict
        modelBuilder.Entity<Vaccine>()
            .HasMany(v => v.VaccinationRecords)
            .WithOne(a => a.Vaccine)
            .HasForeignKey(a => a.VaccineId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Dose to save as a string
        modelBuilder.Entity<VaccinationRecord>()
            .Property(v => v.Dose)
            .HasConversion<string>()
            .IsRequired();

        // Adding indexes for better performance but not realy necessary
        modelBuilder.Entity<VaccinationRecord>()
            .HasIndex(v => v.PersonId);
        modelBuilder.Entity<VaccinationRecord>()
            .HasIndex(v => v.VaccineId);

        // Configure the pk (GUID is OK, but explicit)
        modelBuilder.Entity<Person>().HasKey(p => p.Id);
        modelBuilder.Entity<Vaccine>().HasKey(v => v.Id);
        modelBuilder.Entity<VaccinationRecord>().HasKey(v => v.Id); // Maybe use person.id and Vaccine.id as a composite primary key, i donno, mayby change later
    }
}
