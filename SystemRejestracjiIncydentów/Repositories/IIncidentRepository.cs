using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Repositories
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident?> GetByIdAsync(int id);
        Task<Incident> AddAsync(Incident incident);
        Task<Incident?> UpdateAsync(Incident incident);
        Task<bool> DeleteAsync(int id);
    }

}
