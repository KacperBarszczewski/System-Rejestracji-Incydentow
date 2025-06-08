using Microsoft.EntityFrameworkCore;
using SystemRejestracjiIncydentów.Data;
using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _context;

        public IncidentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await _context.Incidents.Include(i => i.Location).ToListAsync();
        }

        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _context.Incidents.Include(i => i.Location).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Incident> AddAsync(Incident incident)
        {
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
            return incident;
        }

        public async Task<Incident?> UpdateAsync(Incident incident)
        {
            _context.Incidents.Update(incident);
            await _context.SaveChangesAsync();
            return incident;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Incidents.FindAsync(id);
            if (existing == null) return false;

            _context.Incidents.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
