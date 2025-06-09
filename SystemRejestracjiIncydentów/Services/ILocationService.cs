using SystemRejestracjiIncydentów.Common;
using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(int id);
        Task<Result<Location>> CreateAsync(Location location);
        Task<Result<Location>> UpdateAsync(int id, Location location);
        Task<Result<bool>> DeleteAsync(int id);
    }

}
