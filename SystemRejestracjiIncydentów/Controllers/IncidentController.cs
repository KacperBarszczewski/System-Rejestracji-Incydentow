using Microsoft.AspNetCore.Mvc;
using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Services;

namespace SystemRejestracjiIncydentów.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _service;

        public IncidentController(IIncidentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _service.GetAllAsync();
            return Ok(incidents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await _service.GetByIdAsync(id);
            return incident == null ? NotFound() : Ok(incident);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncidentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.AddAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] IncidentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? NoContent() : NotFound(result.Error);
        }

        [HttpPatch("complete/{id}")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var result = await _service.MarkAsResolvedAsync(id);
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
        }
    }
}
