using api.Domain.Entities;
using api.Domain.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
   private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.Persons.AsNoTracking().ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await _context.Persons
            .Include(p => p.VaccinationRecords)
            .ThenInclude(v => v.Vaccine)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Person entity)
    {
        await _context.Persons.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Person entity)
    {
        _context.Persons.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Persons.AnyAsync(p => p.Id == id);
    }
}
