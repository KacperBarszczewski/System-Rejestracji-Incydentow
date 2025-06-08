using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(int id);
        Task<Location> CreateAsync(Location location);
        Task<Location?> UpdateAsync(int id, Location location);
        Task<bool> DeleteAsync(int id);
    }

}
