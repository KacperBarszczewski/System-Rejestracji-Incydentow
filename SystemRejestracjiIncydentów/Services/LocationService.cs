using SystemRejestracjiIncydentów.Common;
using SystemRejestracjiIncydentów.Entities;
using SystemRejestracjiIncydentów.Repositories;

namespace SystemRejestracjiIncydentów.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;

        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Result<Location>> CreateAsync(Location location)
        {
            if (string.IsNullOrWhiteSpace(location.Name))
                return Result<Location>.Failure("Name is required.");

            var created = await _repository.AddAsync(location);
            return Result<Location>.Success(created);
        }

        public async Task<Result<Location>> UpdateAsync(int id, Location location)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return Result<Location>.Failure("Location not found.");

            existing.Name = location.Name;
            existing.Description = location.Description;
            existing.Status = location.Status;

            var updated = await _repository.UpdateAsync(existing);
            return Result<Location>.Success(updated!);
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Location not found.");
        }
    }

}
