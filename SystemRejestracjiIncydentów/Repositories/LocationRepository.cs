using Microsoft.EntityFrameworkCore;
using SystemRejestracjiIncydentów.Data;
using SystemRejestracjiIncydentów.Entities;
using SystemRejestracjiIncydentów.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly AppDbContext _context;

    public LocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<Location?> GetByIdAsync(int id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public async Task<Location> AddAsync(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return location;
    }

    public async Task<Location?> UpdateAsync(Location location)
    {
        _context.Locations.Update(location);
        await _context.SaveChangesAsync();
        return location;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null) return false;

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
        return true;
    }
}
