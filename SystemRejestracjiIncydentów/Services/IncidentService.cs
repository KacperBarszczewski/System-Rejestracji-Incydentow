using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Entities;
using SystemRejestracjiIncydentów.Repositories;

namespace SystemRejestracjiIncydentów.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _repository;
        private readonly ILocationRepository _locationRepository;

        public IncidentService(IIncidentRepository repository, ILocationRepository locationRepository)
        {
            _repository = repository;
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Incident?> AddAsync(IncidentCreateDto dto)
        {
            var location = await _locationRepository.GetByIdAsync(dto.LocationId);
            if (location == null)
                return null;


            var incident = new Incident
            {
                LocationId = dto.LocationId,
                Description = dto.Description,
                OccurredAt = dto.OccurredAt ?? DateTime.Now,
                ResolvedAt = dto.ResolvedAt,
                Priority = dto.Priority,
                Status = dto.Status
            };

            return await _repository.AddAsync(incident);
        }

        public async Task<Incident?> UpdateAsync(int id, IncidentCreateDto updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            var location = await _locationRepository.GetByIdAsync(updated.LocationId);

            if (existing == null || location == null) return null;

            existing.Description = updated.Description;
            existing.OccurredAt = updated.OccurredAt ?? DateTime.Now;
            existing.ResolvedAt = updated.ResolvedAt;
            existing.Priority = updated.Priority;
            existing.Status = updated.Status;
            existing.LocationId = updated.LocationId;

            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
