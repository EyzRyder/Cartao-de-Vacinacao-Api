using api.Domain.Entities;
using api.Domain.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories;

public class VaccineRepository : IVaccineRepository
{
    private readonly AppDbContext _context;

    public VaccineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vaccine>> GetAllAsync()
    {
        return await _context.Vaccines.AsNoTracking().ToListAsync();
    }

    public async Task<Vaccine?> GetByIdAsync(Guid id)
    {
        return await _context.Vaccines
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task AddAsync(Vaccine entity)
    {
        await _context.Vaccines.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vaccine entity)
    {
        _context.Vaccines.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Vaccines.FindAsync(id);
        if (entity != null)
        {
            _context.Vaccines.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Vaccines.AnyAsync(v => v.Id == id);
    }
}
