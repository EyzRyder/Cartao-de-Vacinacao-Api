using api.Domain.Entities;
using api.Domain.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories;

public class VaccinationRecordRepository : IVaccinationRecordRepository
{
    private readonly AppDbContext _context;

    public VaccinationRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VaccinationRecord>> GetByPersonIdAsync(Guid personId)
    {
        return await _context.VaccinationRecords
            .Include(v => v.Vaccine)
            .Where(v => v.PersonId == personId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<VaccinationRecord>> GetByVaccineIdAsync(Guid vaccineId)
    {
        return await _context.VaccinationRecords
            .Include(v => v.Person)
            .Where(v => v.VaccineId == vaccineId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<VaccinationRecord>> GetAllAsync()
    {
        return await _context.VaccinationRecords
            .Include(v => v.Person)
            .Include(v => v.Vaccine)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<VaccinationRecord?> GetByIdAsync(Guid id)
    {
        return await _context.VaccinationRecords
            .Include(v => v.Person)
            .Include(v => v.Vaccine)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task AddAsync(VaccinationRecord entity)
    {
        await _context.VaccinationRecords.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VaccinationRecord entity)
    {
        _context.VaccinationRecords.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.VaccinationRecords.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.VaccinationRecords.AnyAsync(v => v.Id == id);
    }
}
