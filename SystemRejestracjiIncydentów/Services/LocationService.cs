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

        public async Task<Location> CreateAsync(Location location)
        {

            return await _repository.AddAsync(location);
        }

        public async Task<Location?> UpdateAsync(int id, Location location)
        {
            var location2 = await _repository.GetByIdAsync(id);
            if (location2 == null) return null;

            location2.Name = location.Name;
            location2.Description = location.Description;
            location2.Status = location.Status;

            return await _repository.UpdateAsync(location2);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}
