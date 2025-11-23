using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Mappings;

public class VaccineMapping : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.ToTable("Vacinas");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(150);

        // Vaccine -> VaccinationRecords (1:N) One to many with delete restrict
        builder.HasMany(p => p.VaccinationRecords)
            .WithOne(v => v.Vaccine)
            .HasForeignKey(v => v.VaccineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
