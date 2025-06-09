using SystemRejestracjiIncydentów.Common;
using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident?> GetByIdAsync(int id);
        Task<Result<Incident>> AddAsync(IncidentCreateDto dto);
        Task<Result<Incident>> UpdateAsync(int id, IncidentCreateDto incident);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<Incident>> MarkAsResolvedAsync(int id);
    }
}
