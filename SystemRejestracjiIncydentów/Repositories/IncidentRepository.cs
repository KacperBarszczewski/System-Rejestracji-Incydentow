using Microsoft.EntityFrameworkCore;
using SystemRejestracjiIncydentów.Data;
using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Repositories
{
    public class EfIncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _context;

        public EfIncidentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Incident?> GetByIdAsync(int id) =>
            await _context.Incidents.FindAsync(id);

        public async Task<IEnumerable<Incident>> GetAllAsync() =>
            await _context.Incidents.Include(i => i.Location).ToListAsync();

        public async Task AddAsync(Incident incident) =>
            await _context.Incidents.AddAsync(incident);

        public async Task UpdateAsync(Incident incident) =>
            _context.Incidents.Update(incident);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }

}
