using SystemRejestracjiIncydentów.Common;
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

        public async Task<Result<Incident>> AddAsync(IncidentCreateDto dto)
        {
            if (dto.LocationId == null)
                return Result<Incident>.Failure("LocationId is required.");

            var location = await _locationRepository.GetByIdAsync(dto.LocationId.Value);
            if (location == null)
                return Result<Incident>.Failure($"Location with ID {dto.LocationId.Value} not found.");


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
                return Result<Incident>.Failure("ResolvedAt cannot be earlier than OccurredAt.");

            var created = await _repository.AddAsync(incident);
            return Result<Incident>.Success(created);
        }

        public async Task<Result<Incident>> UpdateAsync(int id, IncidentCreateDto updated)
        {

            if (updated.LocationId == null)
                return Result<Incident>.Failure("LocationId is required.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return Result<Incident>.Failure("Incident not found.");

            var location = await _locationRepository.GetByIdAsync(updated.LocationId.Value);
            if (location == null)
                return Result<Incident>.Failure($"Location with ID {updated.LocationId.Value} not found.");

            existing.Description = updated.Description ?? string.Empty;
            existing.OccurredAt = updated.OccurredAt ?? DateTime.Now;
            existing.ResolvedAt = updated.ResolvedAt;
            existing.Priority = updated.Priority;
            existing.Status = updated.Status;
            existing.LocationId = updated.LocationId.Value;

            if (existing.ResolvedAt < existing.OccurredAt)
                return Result<Incident>.Failure("ResolvedAt cannot be earlier than OccurredAt.");

            var updatedIncident = await _repository.UpdateAsync(existing);
            return Result<Incident>.Success(updatedIncident!);
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Incident not found.");
        }

        public async Task<Result<Incident>> MarkAsResolvedAsync(int id)
        {
            var incident = await _repository.GetByIdAsync(id);
            if (incident == null)
                return Result<Incident>.Failure("Incident not found.");

            incident.Status = IncidentStatus.Closed;
            incident.ResolvedAt = DateTime.Now;

            var updated = await _repository.UpdateAsync(incident);
            return Result<Incident>.Success(updated!);
        }
    }
}
