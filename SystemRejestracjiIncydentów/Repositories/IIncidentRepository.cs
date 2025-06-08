using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Repositories
{
    public interface IIncidentRepository
    {
        Task<Incident?> GetByIdAsync(int id);
        Task<IEnumerable<Incident>> GetAllAsync();
        Task AddAsync(Incident incident);
        Task UpdateAsync(Incident incident);
        Task SaveChangesAsync();
    }

}
