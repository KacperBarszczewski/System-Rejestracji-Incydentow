using Microsoft.AspNetCore.Mvc;
using SystemRejestracjiIncydentów.Entities;
using SystemRejestracjiIncydentów.Services;

namespace SystemRejestracjiIncydentów.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _service;

        public LocationsController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _service.GetAllAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _service.GetByIdAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Location location)
        {
            var created = await _service.CreateAsync(location);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Location location)
        {
            var updated = await _service.UpdateAsync(id, location);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
