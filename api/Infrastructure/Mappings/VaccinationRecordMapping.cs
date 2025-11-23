using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Mappings;

public class VaccinationRecordMapping : IEntityTypeConfiguration<VaccinationRecord>
{
    public void Configure(EntityTypeBuilder<VaccinationRecord> builder)
    {
        builder.ToTable("VaccinationRecord");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.DateAplication)
            .IsRequired();

        builder.Property(v => v.Dose)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(20);

        // Indexes to make searches easier
        builder.HasIndex(v => v.PersonId);
        builder.HasIndex(v => v.VaccineId);

        // Relations
        builder.HasOne(v => v.Person)
            .WithMany(p => p.VaccinationRecords)
            .HasForeignKey(v => v.PersonId);

        builder.HasOne(v => v.Vaccine)
            .WithMany()
            .HasForeignKey(v => v.VaccineId);
    }
}
