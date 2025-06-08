using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident?> GetByIdAsync(int id);
        Task<Incident?> AddAsync(IncidentCreateDto dto);
        Task<Incident?> UpdateAsync(int id, IncidentCreateDto incident);
        Task<bool> DeleteAsync(int id);
        Task<Incident?> MarkAsResolvedAsync(int id);
    }
}
