using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Repositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(int id);
        Task<Location> AddAsync(Location location);
        Task<Location?> UpdateAsync(Location location);
        Task<bool> DeleteAsync(int id);
    }
}
