using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Entities;
using SystemRejestracjiIncydentów.Enums;
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
            if (dto.LocationId == null) return null;


            var location = await _locationRepository.GetByIdAsync(dto.LocationId.Value);
            if (location == null)
                return null;


            var incident = new Incident
            {
                LocationId = dto.LocationId.Value,
                Description = dto.Description ?? string.Empty,
                OccurredAt = dto.OccurredAt ?? DateTime.Now,
                ResolvedAt = dto.ResolvedAt,
                Priority = dto.Priority,
                Status = dto.Status
            };

            if (incident.ResolvedAt < incident.OccurredAt)
                return null;

            return await _repository.AddAsync(incident);
        }

        public async Task<Incident?> UpdateAsync(int id, IncidentCreateDto updated)
        {
            if (updated.LocationId == null) return null;

            var existing = await _repository.GetByIdAsync(id);
            var location = await _locationRepository.GetByIdAsync(updated.LocationId.Value);

            if (existing == null || location == null) return null;

            existing.Description = updated.Description ?? string.Empty;
            existing.OccurredAt = updated.OccurredAt ?? DateTime.Now;
            existing.ResolvedAt = updated.ResolvedAt;
            existing.Priority = updated.Priority;
            existing.Status = updated.Status;
            existing.LocationId = updated.LocationId.Value;

            return await _repository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Incident?> MarkAsResolvedAsync(int id)
        {
            var incident = await _repository.GetByIdAsync(id);
            if (incident == null) return null;

            incident.Status = IncidentStatus.Closed;
            incident.ResolvedAt = DateTime.Now;

            return await _repository.UpdateAsync(incident);
        }
    }
}
